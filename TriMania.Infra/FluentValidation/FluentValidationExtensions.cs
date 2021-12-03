using System;
using FluentValidation;

namespace TriMania.Infra.FluentValidation
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> NaoNuloOuVazio<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotNull().WithMessage("{PropertyName} não pode ser nulo(a) ou vazio(a)")
                .NotEmpty().WithMessage("{PropertyName} não pode ser nulo(a) ou vazio(a)");
            ;
            return options;
        }

        public static IRuleBuilderOptions<T, DateTime> NaoNuloOuVazio<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            var options = ruleBuilder
                .NotNull().WithMessage("{PropertyName} não pode ser nulo(a) ou vazio(a)")
                .NotEmpty().WithMessage("{PropertyName} não pode ser nulo(a) ou vazio(a)");
            ;
            return options;
        }

        public static IRuleBuilderOptions<T, string> NaoSerMaiorQue<T>(this IRuleBuilder<T, string> ruleBuilder,
            int maxLength = 300)
        {
            var options = ruleBuilder.MaximumLength(maxLength)
                .WithMessage("{PropertyName} não pode ser maior que " + maxLength);
            return options;
        }

        public static IRuleBuilderOptions<T, string> NaoSerMenorQue<T>(this IRuleBuilder<T, string> ruleBuilder,
            int minLength = 3)
        {
            var options = ruleBuilder.MinimumLength(minLength)
                .WithMessage("{PropertyName} não pode ser menor que " + minLength);
            return options;
        }

        public static IRuleBuilderOptions<T, string> NaoPossuiCaracteresEspeciais<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            int minLength = 3)
        {
            var options = ruleBuilder.Matches("^[a-zA-Z0-9 ]*$")
                .WithMessage("{PropertyName} não aceita caracteres especiais");

            return options;
        }
    }
}