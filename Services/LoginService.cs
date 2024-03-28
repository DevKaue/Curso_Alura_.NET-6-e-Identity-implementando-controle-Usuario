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

        public LoginService(IMapper mapper, SignInManager<Usuario> signInManager)
        {
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task Login(LoginUsuarioDto dto)
        {
            try 
            {
                var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
                if (!resultado.Succeeded)
                {
                    throw new ApplicationException("Usuário sem autenticação");
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Erro apresentado: " + ex.Message);
            }
        }
    }
}
