﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Models;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {

            var streamerEntity = _mapper.Map<Streamer>(request);
            var newStreamer = await _streamerRepository.AddAsync(streamerEntity);
            _logger.LogInformation($"streamer {newStreamer.Id} fue creado exitosamente");
            await SendEmail(newStreamer);
            return newStreamer.Id;

        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "corredor.wolfang@gmail.com",
                Body ="El correo se creo correctamente",
                Subject ="Mensaje de texto creado correctamente"
                
            };
            try
            {
                await _emailService.SendEmail(email);

            }catch (Exception ex)
            {
                _logger.LogError($"El email no se pudo enviar mail de{streamer.Id} por: {ex.Message}");
            }
        }

    }
}
