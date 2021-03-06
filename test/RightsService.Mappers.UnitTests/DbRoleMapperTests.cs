﻿using LT.DigitalOffice.RightsService.Mappers.Db;
using LT.DigitalOffice.RightsService.Mappers.Interfaces;
using LT.DigitalOffice.RightsService.Models.Db;
using LT.DigitalOffice.RightsService.Models.Dto;
using LT.DigitalOffice.UnitTestKernel;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.RightsService.Mappers.RequestsMappers.UnitTests
{
    internal class DbRoleMapperTests
    {
        private IDbRoleMapper _roleRequestMapper;

        private CreateRoleRequest _request;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _roleRequestMapper = new DbRoleMapper();

            _request = new CreateRoleRequest
            {
                Name = "test name",
                Description = "test descripton",
                Rights = new List<int> { 123 }
            };
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWhenProjectRequestIsNull()
        {
            CreateRoleRequest request = null;

            Assert.Throws<ArgumentNullException>(() => _roleRequestMapper.Map(request, Guid.NewGuid()));
        }
    }
}
