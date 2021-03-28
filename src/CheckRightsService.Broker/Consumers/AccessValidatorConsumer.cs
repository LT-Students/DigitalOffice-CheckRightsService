﻿using LT.DigitalOffice.CheckRightsService.Data.Interfaces;
using LT.DigitalOffice.Kernel.AccessValidatorEngine.Requests;
using LT.DigitalOffice.Kernel.Broker;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.CheckRightsService.Broker.Consumers
{
    public class AccessValidatorConsumer : IConsumer<IAccessValidatorCheckRightsServiceRequest>
    {
        private readonly ICheckRightsRepository repository;

        public AccessValidatorConsumer([FromServices] ICheckRightsRepository repository)
        {
            this.repository = repository;
        }

        public async Task Consume(ConsumeContext<IAccessValidatorCheckRightsServiceRequest> context)
        {
            var response = OperationResultWrapper.CreateResponse(HasRight, context.Message);
            await context.RespondAsync<IOperationResult<bool>>(response);
        }

        private object HasRight(IAccessValidatorCheckRightsServiceRequest request)
        {
            if (repository.IsUserHasRight(request.UserId, request.RightId))
            {
                return true;
            }

            return false;
        }
    }
}
