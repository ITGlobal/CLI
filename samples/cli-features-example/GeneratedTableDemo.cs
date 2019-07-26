using System;
using System.Collections.Generic;
using ITGlobal.CommandLine.Table;

namespace ITGlobal.CommandLine.Example
{
    public static class GeneratedTableDemo
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

        public static void Run(int n)
        {
            var migrations = new[]
            {
                ("NEW", "20180517155304_CreateInstrumentDB"),
                ("NEW", "20180518101017_SetRestrictBehavior"),
                ("NEW", "20180524124820_RenameCurrencyToAsset"),
                ("NEW", "20180627073805_AddedLotPrecision"),
                ("NEW", "20180731141609_AddedStatusTransitionSupport"),
                ("NEW", "20180803082312_AddedCollateralRange"),
                ("NEW", "20180803102741_AlteredCollateralRange"),
                ("NEW", "20180817143915_AddedIndicativeOrdersSupport"),
                ("NEW", "20180822114618_ChangedStatusTransitions"),
                ("NEW", "20180824124512_AddedInstrumentNextTransitionTime"),
                ("NEW", "20180828183838_AddRatesForAsset"),
                ("NEW", "20180830145143_AddMinAmountToWithdraw"),
                ("NEW", "20180924133448_AddedAssetCommissions"),
                ("NEW", "20180925095716_AddedSeparateTakerAndMakerCommission"),
                ("NEW", "20181102110358_AddedReplicationVersion"),
                ("NEW", "20181126114728_AddedLastClearingStatus"),
                ("NEW", "20190215084308_AddedWallets"),
                ("NEW", "20190313123929_AlterationsForLeveragedTrading"),
                ("NEW", "20190314093132_AddedMarginLevelToInstruments"),
                ("NEW", "20190315101912_DroppedCollateralRange"),
                ("NEW", "20190315131902_AddedSettlementDays"),
                ("NEW", "20190326090623_AddedClearingSupport"),
                ("NEW", "20190402072445_AddedAssetRates"),
                ("NEW", "20190402114837_AddedInstrumentPriceRange"),
                ("NEW", "20190404073933_AddedMarginEvaluationParams"),
                ("NEW", "20190408090559_ChangedEnumStorageScheme"),
                ("NEW", "20190412114324_AddedForceNewOperatingDaySupport"),
                ("NEW", "20190418073709_OptionalClearingCompletionTime"),
                ("NEW", "20190508113618_ChangedSomeClearingProperties"),
                ("NEW", "20190517132904_ReturnedCollateralRangeBack"),
                ("NEW", "20190716160012_AddedWithdrawalFeeType"),
                ("NEW", "20190717110922_ChangedClearingToMaintenance"),
            };

            TerminalTable.Create(migrations,TableRenderer.Grid())
                .Column("STATUS", _ => _.Item1)
                .Column("MIGRATION", _ => _.Item2)
                .Draw(str => Console.WriteLine(str));


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

            var renderer = TableRenderer.Grid(GridTableStyle.Pretty());
            var table = TerminalTable.Create(data, renderer);

            table.Column("ID", _ => _.Id);
            table.Column("Image", _ => _.Image);
            table.Column("Created", _ => _.Created);
            table.Column("Status", _ => _.Status, style: _ => _.IsRunning ? ColoredStringStyle.Red : null);
            table.Draw();
        }
    }
}