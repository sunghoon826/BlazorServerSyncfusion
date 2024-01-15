using BlazorServerSyncfusion.Interfaces;
using BlazorServerSyncfusion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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
            return await this._context.TdmsFiles.ToListAsync();
        }

        public TdmsFile GetDetail(int? id)
        {
            if (id == null || _context?.TdmsFiles == null)
            {
                throw new NullReferenceException();
            }

            var validData = this._context.TdmsFiles.FirstOrDefault(x => x.Id == id);

            if (validData != null)
            {
                return validData;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
