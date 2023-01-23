using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Signature_Pad.Models
{
    public class Signature
    {
        [Key]
        public int SignatureId { get; set; }
        [DisplayName("Load Number")]
        [Required]
        public string? LoadNbr { get; set; }
        [DisplayName("Start Time")]
        public DateTime? ActualStart { get; set; }
        [DisplayName("Finish Time")]
        public DateTime? ActualFinish { get; set; }
        public string? Signatures { get; set; }
        [DisplayName("Carrier Name")]
        public string? CarrierName { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Date { get; set; }        
        [DisplayName("MBOL Number")]
        public string? MbolNumber { get; set; }
        public DateTime? ArrivalTime { get; set; }
        [DisplayName("Time Slot")]
        public string? TimeSlot { get; set; }
    }
}
