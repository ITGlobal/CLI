$parts = "$(git describe --abbrev=0 --tags)".Split('.')
$major = [int] ($parts[0])
$minor = [int] ($parts[1])
$patch = [int] ($parts[2])

write-host "current version: " -n; write-host "$major.$minor.$patch" -f yellow

switch ($args[0]) {
    "" {
        exit 0
    }
    "patch" {
        $patch++
    }
    "minor" {
        $patch = 0
        $minor++
    }
    "major" {
        $patch = 0
        $minor = 0
        $major++
    }
    Default {
        write-host "Wrong command!" -f red
        write-host "Type:"
        write-host "  ./version.ps1 patch " -f yellow -n; write-host "to bump patch version"
        write-host "  ./version.ps1 minor " -f yellow -n; write-host "to bump minor version"
        write-host "  ./version.ps1 major " -f yellow -n; write-host "to bump major version"
        exit 1
    }
}

# git tag "$major.$minor.$patch"
write-host "version changed to " -n; write-host "$major.$minor.$patch" -f yellow