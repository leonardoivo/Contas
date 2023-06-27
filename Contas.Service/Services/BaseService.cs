using FluentValidation;
using System.Text.Json;

namespace Contas.Services
{
    public class BaseService
    {
        protected void Validate<TV, TM>(TV validacao, TM viewModel) where TV : AbstractValidator<TM>
        {
            var validador = validacao.Validate(viewModel);

            if (validador.IsValid) return;

        }

    }
}
