using System;
using System.IO;
using System.Linq;
using ITGlobal.CommandLine.Table;
using ITGlobal.CommandLine.Table.Rendering;

namespace ITGlobal.CommandLine.Example
{
    public static class FluentTableDemo
    {
        public static void Run()
        {
            Run("Table demo: grid table with \"pretty\" style", TableRenderer.Grid(GridTableStyle.Pretty()));
            var lightGridTableStyle = GridTableStyle.Pretty(
                bodyColors: ColoredStringStyle.BlackOnWhite,
                frameColors: ColoredStringStyle.DarkGrayOnWhite,
                titleColors: ColoredStringStyle.CyanOnWhite,
                headerColors: ColoredStringStyle.YellowOnWhite,
                footerColors: ColoredStringStyle.BlackOnWhite
            );
            Run("Table demo: grid table with \"pretty-light\" style", TableRenderer.Grid(lightGridTableStyle));
            Run("Table demo: grid table with \"sketch\" style", TableRenderer.Grid(GridTableStyle.Sketch()));
            Run("Table demo: grid table with \"plain\" style", TableRenderer.Plain());
            Run("Table demo: grid table with \"pipe\" style", TableRenderer.Pipe());
        }

        private static void Run(string title, ITableRenderer renderer)
        {
            var table = TerminalTable.CreateFluent(renderer);
            table.Title(title);
            table.Headers("This is", "a header", "row");
            table.Add(_ => _.AddLeftAlign("See").AddLeftAlign("!").Add("This is a left aligned row"));
            table.Add(_ => _.AddMiddleAlign("See").AddMiddleAlign("!").Add("This is a middle aligned row"));
            table.Add(_ => _.AddRightAlign("See").AddRightAlign("!").Add("This is a right aligned row"));
            table.Add("This", "is", "an ordinary row");
            table.Add("This".Cyan(), "is".Red(), "a colored row".Green());
            table.Add("This", "is", $"a {string.Join("-", Enumerable.Repeat("very", 32))} long row that will be wrapped automatically");
            table.Separator();
            table.Add("This", "is", "an row with a leading separator");
            table.Add("This is a spanned row (span is computed automatically)");
            table.Add("This", "is a spanned row (span is computed automatically)");
            table.Add("This", "is", "an ordinary row");
            table.Footer("This is a footer row (colored!)".Green());
            table.Draw();
            table.Draw(TextWriter.Null);
            table.Draw();
            Console.WriteLine();
        }
    }
}
