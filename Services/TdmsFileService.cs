using BlazorServerSyncfusion.Interfaces;
using BlazorServerSyncfusion.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

        // 바이너리 데이터를 double 배열로 변환하는 메소드
        public double[] ConvertToDoubleArray(byte[] data)
        {
            if (data == null || data.Length % 8 != 0)
                return Array.Empty<double>();

            double[] result = new double[data.Length / 8];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = BitConverter.ToDouble(data, i * 8);
            }
            return result;
        }
    }
}
