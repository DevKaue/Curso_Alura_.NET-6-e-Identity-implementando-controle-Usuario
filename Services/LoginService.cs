using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private IMapper _mapper;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public LoginService(IMapper mapper, 
            SignInManager<Usuario> signInManager,
            TokenService tokenService)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
            
        }

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            try 
            {
                var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
                if (!resultado.Succeeded)
                {
                    throw new ApplicationException("Usuário sem autenticação");
                }

                var usuario = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

                var token = _tokenService.GenerateToken(usuario);
                return token;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Erro apresentado: " + ex.Message);
                return null;
            }
        }
    }
}
