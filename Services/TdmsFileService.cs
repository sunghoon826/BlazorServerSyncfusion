using BlazorServerSyncfusion.Interfaces;
using BlazorServerSyncfusion.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerSyncfusion.Services
{
    public class TdmsFileService : IDatabase<TdmsFile>
    {
        private readonly TdmsFilesContext _context;

        public TdmsFileService(TdmsFilesContext context)
        {
            _context = context;
        }

        public async Task<List<TdmsFile>> GetAsync()
        {
            return await _context.TdmsFiles.ToListAsync();
        }

        public TdmsFile GetDetail(int? id)
        {
            if (id == null || _context?.TdmsFiles == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.TdmsFiles.Find(id);
        }

        public List<double> ConvertToDoubleList(byte[] data)
        {
            if (data == null || data.Length % 8 != 0)
                return new List<double>();

            double[] resultArray = new double[data.Length / 8];
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = BitConverter.ToDouble(data, i * 8);
            }

            // 배열을 List<double>로 변환하여 반환
            return new List<double>(resultArray);
        }

        public List<ChartData> ConvertToChartData(byte[] data)
        {
            var doubleList = ConvertToDoubleList(data);
            var chartData = new List<ChartData>();
            double time = 0;
            double timeInterval = 0.078125; // 시간 간격

            foreach (var value in doubleList)
            {
                chartData.Add(new ChartData { Time = time, Value = value });
                time += timeInterval;
            }

            return chartData;
        }
    }

    public class ChartData
    {
        public double Time { get; set; }
        public double Value { get; set; }
    }
}

