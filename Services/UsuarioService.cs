using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public UsuarioService(IMapper mapper,UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Cadastra(CreateUsuarioDto dto)
        {
            try 
            {
                Usuario usuario = _mapper.Map<Usuario>(dto);
                IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

                if (!resultado.Succeeded)
                {
                    throw new ApplicationException("Falha ao cadastrar usuário");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro apresentado: " + ex.Message);
            }
        }
    }
}
