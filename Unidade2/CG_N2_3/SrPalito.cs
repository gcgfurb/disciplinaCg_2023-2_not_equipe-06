#define cg_debug
using CG_Biblioteca;
using System;

namespace gcgcg
{
    internal class SrPalito : Objeto
    {
        private SegReta corpo;
        private Circulo cabeca;
        private double angulo;
        private double raio;
        private double pe;

        public SrPalito(Objeto paiRef, ref char _rotulo) : base(paiRef, ref _rotulo)
        {
            Ponto4D ptoDes = new Ponto4D();
            angulo = 45;
            raio = 0.5;
            var ptoIni = new Ponto4D(pe, 0, 0, 1);
            var ptoFim = Matematica.GerarPtosCirculo(angulo, raio) + ptoIni;
            corpo = new SegReta(paiRef, ref _rotulo, ptoIni, ptoFim);
            cabeca = new Circulo(paiRef, ref _rotulo, raio, ptoDes);
            Atualizar();
        }
        public void Atualizar()
        {
            ConsoleKeyInfo KeyInfo;
            do
            {
                KeyInfo = Console.ReadKey(true);

                switch (KeyInfo.Key)
                {
                    case ConsoleKey.Q:
                        AtualizarPe(-0.1);
                        break;
                    case ConsoleKey.W:
                        AtualizarPe(0.1);
                        break;
                    case ConsoleKey.A:
                        AtualizarRaio(-0.1);
                        break;
                    case ConsoleKey.S:
                        AtualizarRaio(0.1);
                        break;
                    case ConsoleKey.Z:
                        AtualizarAngulo(-5.0);
                        break;
                    case ConsoleKey.X:
                        AtualizarAngulo(5.0);
                        break;
                    default:
                        break;
                }
            }
            while (KeyInfo.Key != ConsoleKey.Escape);
            //base.ObjetoAtualizar();
        }
        public void AtualizarPe(double peInc)
        {
            pe += peInc;
        }
        public void AtualizarRaio(double raioInc)
        {
            raio += raioInc;
        }
        public void AtualizarAngulo(double anguloInc)
        {
            angulo += anguloInc;
        }

#if cg_debug
        public override string ToString()
        {
            string retorno;
            retorno = "__ objeto circulo _ tipo: " + PrimitivaTipo + " _ tamanho: " + PrimitivaTamanho + "\n";
            retorno += base.ImprimeToString();
            return (retorno);
        }
#endif
    }
}