﻿using LT.DigitalOffice.CheckRightsService.Mappers.Interfaces;
using LT.DigitalOffice.CheckRightsService.Models.Db;
using LT.DigitalOffice.CheckRightsService.Models.Dto;
using System;

namespace LT.DigitalOffice.CheckRightsService.Mappers
{
    public class RightsMapper : IMapper<DbRight, Right>
    {
        public Right Map(DbRight value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return new Right
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description
            };
        }
    }
}