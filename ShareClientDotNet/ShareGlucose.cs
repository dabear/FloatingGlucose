using System;


namespace ShareClientDotNet
{
    //json2csharp.com
    internal class ShareGlucose
    {
        public DateTime DT { get; set; }
        public DateTime ST { get; set; }
        //public long Trend { get; set; }
        public ShareGlucoseSlopeOrdinals Trend { get; set; }

        //value should always be in mgdl
        public decimal Value { get; set; }
        public DateTime WT { get; set; }

        public decimal ValueMgdl => this.Value;
        public decimal ValueMmol => Decimal.Round(this.Value / 18.01559M, 1);
        public DateTime LocalTime => this.WT.ToLocalTime();
    }
}