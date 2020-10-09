﻿using FluentValidation;
using LT.DigitalOffice.CheckRightsService.Business.Interfaces;
using LT.DigitalOffice.CheckRightsService.Data.Interfaces;
using LT.DigitalOffice.CheckRightsService.Models.Dto;
using LT.DigitalOffice.Kernel.AccessValidator.Interfaces;
using LT.DigitalOffice.Kernel.Exceptions;
using LT.DigitalOffice.Kernel.FluentValidationExtensions;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.CheckRightsService.Business
{
    public class AddRightsForUserCommand : IAddRightsForUserCommand
    {
        private readonly ICheckRightsRepository repository;
        private readonly IValidator<AddRightsForUserRequest> validator;
        private readonly IAccessValidator accessValidator;

        public AddRightsForUserCommand(
            [FromServices] ICheckRightsRepository repository,
            [FromServices] IValidator<AddRightsForUserRequest> validator,
            IAccessValidator accessValidator)
        {
            this.repository = repository;
            this.validator = validator;
            this.accessValidator = accessValidator;
        }

        public void Execute(AddRightsForUserRequest request)
        {
            validator.ValidateAndThrowCustom(request);

            if (!accessValidator.IsAdmin())
            {
                throw new ForbiddenException("You need to be an admin to add rights.");
            }

            repository.AddRightsToUser(request);
        }
    }
}