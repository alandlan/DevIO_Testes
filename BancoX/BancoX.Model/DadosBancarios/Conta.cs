using BancoX.Model.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoX.Model.DadosBancarios
{
    public  class Conta : Entity
    {
        public int Numero { get; private set; }
        public int Agencia { get; private set; }
        public int Digito { get; private set; }
        public TipoConta TipoConta { get; private set; }
        public float Saldo { get; private set; }
        public bool Ativo { get; private set; }

        public Conta(int agencia, int digito, TipoConta tipoConta)
        {
            Agencia = agencia;
            Digito = digito;
            TipoConta = tipoConta;
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public bool IncluirNumeroConta(int numero)
        {
            if (Numero > 0)
                return false;

            Numero = numero;

            return true;
        } 

        public bool EhValido()
        {
            ValidationResult = new ContaValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ContaValidacao : AbstractValidator<Conta>
    {
        public ContaValidacao()
        {
            RuleFor(c => c.Agencia)
                .NotEmpty().WithMessage("Por favor informe o número da agência");

            RuleFor(c => c.Digito)
                .NotEmpty().WithMessage("Por favor informe o número do digito")
                .InclusiveBetween(1,99)
                .WithMessage("O Digito deve ter entre 1 e 99");

            RuleFor(c => c.Digito)
                .NotEmpty().WithMessage("Por favor informe o número do digito")
                .Must(ValidarDigito)
                .WithMessage("O Digito deve ter entre 1 e 99");

            RuleFor(c => c.TipoConta)
                .NotNull().WithMessage("Informe o tipo de Conta");

            RuleFor(c => c.Numero)
                .GreaterThanOrEqualTo(1).WithMessage("O numero da conta deve ser maior que 0.");
        }

        public static bool ValidarDigito(int digito)
        {
            return (digito > 0 && digito < 100);
        }
    }
}
