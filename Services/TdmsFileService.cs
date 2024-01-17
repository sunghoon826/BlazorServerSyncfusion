using BlazorServerSyncfusion.Interfaces;
using BlazorServerSyncfusion.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
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

            var file = _context.TdmsFiles.Find(id);
            if (file != null)
            {
                // 바이너리 데이터를 JSON 문자열로 변환
                string jsonString = ConvertToJSON(file);
                // 여기서 JSON 문자열을 처리하거나 반환
            }

            return file;
        }

        private string ConvertToJSON(TdmsFile file)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(file, options);
        }
    }


    public class ChartData
    {
        public double Time { get; set; } // 바이너리로 들어가는 문제
        public double Value { get; set; }
    }
}

