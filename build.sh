#!/usr/bin/env bash
set -e

print_title() {
    SEP="============================================" 
    printf "$SEP[\e[1m\e[36m %-10s \e[0m]$SEP\n" "$*"
}

CONFIGURATION=
VERSION=

while [[ $# -gt 0 ]]
do
key="$1"

case $key in
    -c|--config|--configuration)
    CONFIGURATION="$2"
    shift
    shift
    ;;
    -v|--version)
    VERSION="$2"
    shift
    shift
    ;;
    -?|--h|--help)
    echo "Usage:"
    echo "./build.sh [--config CONFIG] [--version VERSION]"
    exit 0
    ;;
    *)
    echo "Unknown option: \"$1\". Type \"./build.sh --help\" to get help."
    exit 1
    ;;
esac
done

SOLUTION_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"
ARTIFACTS="$SOLUTION_DIR/artifacts"
if [[ -z "$CONFIGURATION" ]]; then
    CONFIGURATION="Release"
fi

echo "SOLUTION_DIR:  $SOLUTION_DIR"
echo "ARTIFACTS:     $ARTIFACTS"
echo "CONFIGURATION: $CONFIGURATION"

# CLEAN
print_title "CLEAN"
mkdir -p $ARTIFACTS
rm -rf $ARTIFACTS/*.nupkg
dotnet clean -v q /nologo
echo "Dropped build output"


# VERSION
print_title "VERSION"

if [[ -z "$VERSION" ]]; then
    TAGS=$(git tag)
    if [[ -z "$(git tag)" ]]; then
        VERSION="0.0.0-dev"
        echo "there are no tags! Will use '$VERSION' as version number"
    else
        VERSION=$(git describe --abbrev=0 --tags)
    fi
fi

if [[ ! -z "$APPVEYOR_BUILD_NUMBER" ]]; then
    if [[ "$APPVEYOR_REPO_TAG" != "true" ]]; then
        TAG=$(git log -n 1 --pretty=format:%h)
        VERSION="$VERSION-$TAG+$APPVEYOR_BUILD_NUMBER"
    fi
fi

echo "Version number : $VERSION"

if [[ ! -z "$APPVEYOR" ]]; then
    appveyor SetVariable -Name VERSION -Value $VERSION
    appveyor UpdateBuild -Version "$VERSION"
fi


# COMPILE
print_title "COMPILE"
dotnet build -v q -c $CONFIGURATION /nologo /p:Version=$VERSION /p:NoWarn=3245

# TEST
print_title "TEST"
dotnet test -v q -c $CONFIGURATION --no-restore --no-build /nologo

# PACK
print_title "PACK"
dotnet pack /nologo -v q -c $CONFIGURATION /p:Version=$VERSION --include-symbols --include-source --no-restore --no-build --output $ARTIFACTS ./CLI.sln

echo "Generated packages:"
for filename in $(ls -1 -p $ARTIFACTS/*.nupkg); do
    filename=$(basename $filename $ARTIFACTS)
    echo "  $filename"
done

print_title "COMPLETED"