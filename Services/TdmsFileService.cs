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
            if (id == null)
                throw new ArgumentNullException(nameof(id), "ID cannot be null.");

            if (_context?.TdmsFiles == null)
                throw new InvalidOperationException("Database context not initialized.");

            var file = _context.TdmsFiles.Find(id);
            return file; // 여기서 필요한 경우 추가 처리를 수행
        }
    }


    public class ChartData
    {
        public double Time { get; set; }
        public double Value { get; set; }
    }
}

