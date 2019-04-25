using System;
using System.Collections.Generic;
using ITGlobal.CommandLine.Table;

namespace ITGlobal.CommandLine.Example
{
    public static class TableDemo
    {
        class TableRow
        {
            public TableRow(string id, string image, string created, string status, bool isRunning)
            {
                Id = id;
                Image = image;
                Created = created;
                Status = status;
                IsRunning = isRunning;
            }

            public string Id { get; }
            public string Image { get; }
            public string Created { get; }
            public string Status { get; }
            public bool IsRunning { get; }
        }

        public static void Run(bool paged, int n)
        {
            var data = new List<TableRow>();
            for (var x = 0; x <= n; x++)
            {
                data.Add(new TableRow(
                    "16ecd05ab21c",
                    "foobar/image:latest",
                    x % 3 == 0 ? "1 month ago" : "2 weeks ago",
                    x % 3 == 1 ? "Up 2 days" : "Exited (0) 2 days ago",
                    x % 3 == 2
                ));
            }

            var table = TerminalTable.Create(data, paged ? TableRenderer.Paged() : null);

            table.Column("ID", _ => _.Id);
            table.Column("Image", _ => _.Image);
            table.Column("Created", _ => _.Created);
            table.Column("Status", _ => _.Status, fg: _ => _.IsRunning ? ConsoleColor.Red : (ConsoleColor?)null);
            table.Draw();
        }
    }
}