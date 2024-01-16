using System;
using System.Collections.Generic;

namespace BlazorServerSyncfusion.Models;

public partial class TdmsFile
{
    public int Id { get; set; } // auto increase number id

    public string FileName { get; set; } = null!; //TDMS file name

    public byte[] Data { get; set; } = null!; //12800 or 6400
}
