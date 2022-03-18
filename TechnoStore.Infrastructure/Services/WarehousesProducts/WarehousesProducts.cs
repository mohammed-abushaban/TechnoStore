using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.WarehousesProducts;
using TechnoStore.Core.ViewModel.WareHouses;
using TechnoStore.Data.Data;
using TechnoStore.Infrastructure.Services.Files;

namespace TechnoStore.Infrastructure.Services.WarehousesProducts
{
    public class WarehousesProducts : IWarehousesProducts
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public static double NumOfPages;
        private readonly IFileService _fileService;

        public WarehousesProducts(ApplicationDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
        }

        //public async Task<bool> Save(string userId, CreateWarehouseProductDto dto)
        //{
            
        //}

        
    }
}
