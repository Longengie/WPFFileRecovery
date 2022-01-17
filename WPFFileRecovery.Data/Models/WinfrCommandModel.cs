using WPFFileRecovery.Data.Helpers;

namespace WPFFileRecovery.Data.Models
{
    /// <summary>
    /// Winfr Command Model
    /// </summary>
    public class WinfrCommandModel
    {
        public string? Source { get; set; }
        public string? Destination { get; set; }
        public string SourceDrive => WinfrCommandModelHelper.GetDirectionSourceDrive(Source);
        public string DestinationDrive => WinfrCommandModelHelper.GetDirectionSourceDrive(Destination);
        public string SourceRelative => WinfrCommandModelHelper.GetRelativeDirection(Source);
        public string DestinationRelative => WinfrCommandModelHelper.GetRelativeDirection(Destination);
        public bool SourceIsFolder => WinfrCommandModelHelper.CheckIsFolder(Source);
        public bool DestinationIsFolder => WinfrCommandModelHelper.CheckIsFolder(Destination);
        public string SourceDriveType => WinfrCommandModelHelper.GetDriveType(SourceDrive);
        /// <summary>
        /// 
        /// </summary>
        public string DestinationDriveType => WinfrCommandModelHelper.GetDriveType(DestinationDrive);
        public bool IsExtensive { get; set; }    
        public string? FileMode { get; set; }
        /// <summary>
        /// Search List
        /// </summary>
        public List<string>? Search { get; set; }
    }
}
