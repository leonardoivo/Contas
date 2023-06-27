using AutoMapper;
using System.Linq;
using Contas.Application.ViewModels;
using Contas.Application.ViewModels.Conta;
using Contas.Domain.Models;
using Contas.Domain.DTO;


namespace Contas.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ModelPaginada<ContaModel>, ViewModelPaginada<ContaViewModel>>();
            CreateMap<ContaModel, ContaViewModel>();
           
        }
    }
}