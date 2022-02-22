using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Admin.Controllers;
using Rookie.Ecom.Business;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor;
using Rookie.Ecom.DataAccessor.Entities;
using Rookie.Ecom.DataAccessor.Interfaces;
using Rookie.Ecom.IntegrationTests.Common;
using Rookie.Ecom.Tests;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.Ecom.IntegrationTests
{
    public class CityControllerShould : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;
        private readonly IBaseRepository<City> _CityRepository;
        private readonly IMapper _mapper;

        public CityControllerShould(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
            _CityRepository = new BaseRepository<City>(_fixture.Context);
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Add_New_City_Success()
        {
            // Arrange
            var CityService = new CityService(_CityRepository, _mapper);
            var CityController = new CityController(CityService);
            var newCity = new CityDto { Name = "Test City"};


            // Act
            var result = await CityController.CreateAsync(newCity);

            // Assert
            result.Result.Should().HaveStatusCode(StatusCodes.Status201Created);
            result.Should().NotBeNull();

            var createdResult = Assert.IsType<CreatedResult>(result.Result);
            var returnValue = Assert.IsType<CityDto>(createdResult.Value);

            Assert.Equal(newCity.Name, returnValue.Name);


            returnValue.Id.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public async Task Add_Exist_City_ExistedName()
        {
            // Arrange
            var existCity = new City { Id = Guid.NewGuid(), Name = "CityA" };
            await _CityRepository.AddAsync(existCity);

            var CityService = new CityService(_CityRepository, _mapper);
            var CityController = new CityController(CityService);

            var newCity = new CityDto { Name = "Laptop B"};

            // Act
            var result = await CityController.CreateAsync(newCity);

            // Assert
            result.Result.Should().HaveStatusCode(StatusCodes.Status201Created);
            result.Should().NotBeNull();

            var createdResult = Assert.IsType<CreatedResult>(result.Result);
            var returnValue = Assert.IsType<CityDto>(createdResult.Value);

            Assert.Equal(newCity.Name, returnValue.Name);

            returnValue.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_All_Categories()
        {
            //Arrange
            var City1 = new City { Name = "Cate 1" };
            var City2 = new City { Name = "Cate 2" };
            var City3 = new City { Name = "Cate 3" };
            var City4 = new City { Name = "Cate 4" };
            await _CityRepository.AddAsync(City1);
            await _CityRepository.AddAsync(City2);
            await _CityRepository.AddAsync(City3);
            await _CityRepository.AddAsync(City4);

            var CityService = new CityService(_CityRepository, _mapper);
            var CityController = new CityController(CityService);

            // Act
            var result = await CityController.GetAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(4);
        }
    }
}
