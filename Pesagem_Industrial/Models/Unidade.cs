using System;

namespace Pesagem_Industrial.Models
{
    public class Unidade
    {
        public enum Peso
        {
            KG,
            MG,
            G,
            TON
        };

        public enum Comprimento
        {
            M,
            KM,
            CM,
            MM
        };

        public enum Liquido
        {
            L,
            ML,
            KL
        };

        public enum Unitario
        {
            Peca,
            Unidade
        };
        
    }
}