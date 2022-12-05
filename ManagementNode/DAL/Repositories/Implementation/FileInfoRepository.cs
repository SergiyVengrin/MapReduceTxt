using DAL.Data;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementation
{
    public sealed class FileInfoRepository : IFileInfoRepository
    {
        private readonly NodeDbContext _db;

        public FileInfoRepository(NodeDbContext nodeDbContext)
        {
            _db = nodeDbContext;
        }


        public async Task Add(Entities.FileInfo nodeInfo)
        {
            try
            {
                await _db.NodesInfo.AddAsync(nodeInfo);
                await _db.SaveChangesAsync();
            }
            catch { throw; }
        }


        public async Task Delete(Entities.FileInfo nodeInfo)
        {
            try
            {
                _db.NodesInfo.Remove(nodeInfo);
                await _db.SaveChangesAsync();
            }
            catch { throw; }
        }


        public async Task<Entities.FileInfo> Get(int id)
        {
            try
            {
                return await _db.NodesInfo.SingleAsync(n => n.Id == id);
            }
            catch { throw; }
        }
    }
}
