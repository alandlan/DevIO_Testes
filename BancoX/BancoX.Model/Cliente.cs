using BancoX.Model.Core;
using FluentValidation;
using System;
using BancoX.Model.DadosBancarios;

namespace BancoX.Model
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Email { get; private set; }
        public string Documento { get; private set; }
        public string DocumentoTipo { get; private set; }

        public bool Ativo { get; set; }
        public Conta Conta { get; set; }

        protected Cliente()
        {

        }

        public Cliente(Guid id, string nome,string sobrenome,string documento,string documentoTipo, DateTime dataNascimento, string email) 
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            DocumentoTipo = documentoTipo;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            Email = email;
            Ativo = true;
        }

        public Cliente(Guid id, string nome, string sobrenome, string documento,string documentoTipo, DateTime dataNascimento, string email, Conta conta)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            DocumentoTipo = documentoTipo;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            Email = email;
            Ativo = true;
            Conta = conta;
        }

        public string NomeCompleto()
        {
            return $"{Nome} {Sobrenome}"; 
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public override bool EhValido()
        {
            ValidationResult = new ClienteValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    
    public class ClienteValidacao : AbstractValidator<Cliente>
    {
        public ClienteValidacao()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, certifique o nome inserido")
                .Length(2, 150).WithMessage("O nome deve ser entre 2 e 150 caracteres");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("Por favor, certifique o sobrenome inserido")
                .Length(2, 150).WithMessage("O sobrenome deve ser entre 2 e 150 caracteres");

            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("O cliente deve ter 18 anos ou mais");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        public static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}
