using AutoMapper;
using Crowdfunding.Application.Models;
using Crowdfunding.Identity.Models;
using Crowdfunding.Identity.Services;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Account
{
    public class LoginHandler : IRequestHandler<LoginReq, ResponseData<LoginRes>>
    {
        JWTService jWTService;
        AccountRepository accountRepository;
        public LoginHandler(JWTService jWTService, AccountRepository accountRepository)
        {
            this.jWTService = jWTService;
            this.accountRepository = accountRepository;
        }

        //擇一選擇做使用，如果API要回傳資料就選擇 ResponseData，如果不需要回傳資料就選擇Response
        public async Task<ResponseData<LoginRes>> Handle(LoginReq request, CancellationToken cancellationToken)
        {
            UserModels userModel = accountRepository.Login(request.Account, request.Password);
            if (userModel == null)
                return await Task.FromResult(new ResponseData<LoginRes>(false, "登入失敗，請重新輸入帳號與密碼"));
            var genearteTokenDTO = new GenearteTokenDTO(userModel.Id.ToString(), userModel.Name, userModel.Email, "09xxxxxx");
            var token = this.jWTService.GenerateTokenByAccount(genearteTokenDTO);
            LoginRes res = new LoginRes();
            res.UserID = userModel.Id;
            res.Token = token;
            res.Email = userModel.Email;
            return await Task.FromResult(new ResponseData<LoginRes>(res));

        }
    }
}