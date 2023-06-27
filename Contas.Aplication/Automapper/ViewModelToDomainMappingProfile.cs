using AutoMapper;
using System.Linq;
using Contas.Application.ViewModels.Conta;
using Contas.Domain.Models;

namespace Contas.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ContaModel, ContaViewModel>();
        }
    }
}
