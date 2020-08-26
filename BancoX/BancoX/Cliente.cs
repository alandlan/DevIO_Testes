using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoX.Model
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Documento Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public Conta Conta { get; set; }

        protected Cliente()
        {

        }

        public Cliente(Guid id, string nome,string sobrenome,Documento documento, DateTime dataNascimento, string email) 
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            Email = email;
            Ativo = true;
        }

        public Cliente(Guid id, string nome, string sobrenome, Documento documento, DateTime dataNascimento, string email, Conta conta)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
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
            return true; 
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
