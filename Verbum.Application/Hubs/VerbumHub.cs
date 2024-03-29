﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Hubs.dtos;
using Verbum.Application.Interfaces;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Hubs
{
    public class VerbumHub : Hub
    {
        private readonly IVerbumDbContext _dbContext;

        public VerbumHub(IVerbumDbContext dbContext) => _dbContext = dbContext;

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"Приветствуем {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }


        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var user = await _dbContext.Users.SingleAsync(i => i.HubConnectionId == Context.ConnectionId);
            if (user != null)
            {
                user.HubConnectionId = "";
                user.IsOnline = false;
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                await Clients.All.SendAsync("userIsOffline", user.NickName);
            }



            await base.OnDisconnectedAsync(exception);
        }

        public async Task ReactionActivity(ReactionActivityDto dto) {

            await Clients.All.SendAsync("ReactionActive", dto);

        }

        public async Task UserTypingMessage(UserTypingDto dto) {
            var user = await _dbContext.Users.SingleAsync(u => u.Id == dto.User);
            if (user != null) {
                if (user.IsOnline) {
                    await Clients.Client(user.HubConnectionId).SendAsync("TypingMessage", dto.FromWho);
                }
            }
        }

        public async Task SendMessage(Messages message) =>
            await Clients.All.SendAsync("receiveMessage", message);


        public async Task SuccessRegistration(string nickname) {
            await Clients.All.SendAsync("userIsOnline", nickname);
        }


        public async Task RegisterUserOnline(string NickName)
        {
            var user = await _dbContext.Users.SingleAsync(i => i.NickName == NickName);
            if (user != null)
            {
                user.IsOnline = true;
                user.HubConnectionId = Context.ConnectionId;

                await _dbContext.SaveChangesAsync(CancellationToken.None);

                await Clients.Client(Context.ConnectionId).SendAsync("regOk");

            }

        }


        public async Task AskTheUserForCall(AskUserForCallDto dto) 
        {
            var user = await _dbContext.Users.SingleAsync(i => i.NickName == dto.UserNickname);

            if (user != null) 
            {
                if (user.IsOnline) 
                {
                    await Clients.Client(user.HubConnectionId).SendAsync("UserAskForCall", 
                        new AskForCallReceivedto {UserNickname = dto.MyNickname, CallType = dto.CallType });
                }
            }
        }

        public async Task UserConfirmedCall(string Nickname) 
        {
            
            var user = await _dbContext.Users.SingleAsync(i => i.NickName == Nickname);

            if (user != null)
            {
                if (user.IsOnline)
                {
                    await Clients.Client(user.HubConnectionId).SendAsync("CallConfirmed");
                }
            }

        }

        public async Task CallToUser(CallToUserDto dto) 
        {
            var user = await _dbContext.Users.SingleAsync(i => i.Id == dto.UserToCall);

            if (user != null) {
                if (user.IsOnline) 
                {
                    await Clients.Client(user.HubConnectionId).SendAsync("UserCalling", dto.SignalData);
                }
            }
        }

        public async Task AnswerToUserCall(AnswerToCallDto dto) 
        {
            var user = await _dbContext.Users.SingleAsync(i => i.NickName == dto.UserNickname);

            if (user != null) {
                if (user.IsOnline) {
                    await Clients.Client(user.HubConnectionId).SendAsync("UserAnswerToCall", dto.Signal);
                }
            }
        }

        public async Task SetOfferIceCandidate(SetIceCandidateDto dto) {
           
            var user = await _dbContext.Users.SingleAsync(i => i.NickName == dto.UserNickname);

            if (user != null)
            {
                if (user.IsOnline)
                {
                    await Clients.Client(user.HubConnectionId).SendAsync("OfferIceCandidate", dto.IceCandidate);
                }
            }
        }


        public async Task SetAnswerIceCandidate(SetIceCandidateDto dto)
        {

            var user = await _dbContext.Users.SingleAsync(i => i.NickName == dto.UserNickname);

            if (user != null)
            {
                if (user.IsOnline)
                {
                    await Clients.Client(user.HubConnectionId).SendAsync("AnswerIceCandidate", dto.IceCandidate);
                }
            }
        }

        public async Task UserCancelCall(string NickName) 
        {
            var user = await _dbContext.Users.SingleAsync(i => i.NickName == NickName);

            if (user != null) 
            {
                if (user.IsOnline) 
                {
                    await Clients.Client(user.HubConnectionId).SendAsync("CanselingCall");
                }
            }
        }
    }
}
