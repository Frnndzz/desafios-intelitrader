
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 

public class LivroDeOfertas
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Digite o número de notificações a serem enviadas: ");
        int qtdNotificacoes = toInt(Console.ReadLine());

        while (qtdNotificacoes < 1)
        {
            Console.WriteLine("\nO número de notificações deve ser pelo menos 1.");
            Console.WriteLine("Digite o número de notificações a serem enviadas: ");
            qtdNotificacoes = toInt(Console.ReadLine());
        }

        List<Oferta> ofertas = new List<Oferta>();


        Console.WriteLine("\nDigite as notificações: ");

        for (int i = 0; i < qtdNotificacoes; i++)
        {
            String notificacao = Console.ReadLine();

            String[] dadosNotificacao = notificacao.Split(',');
            int posicao = toInt(dadosNotificacao[0]);
            int acao = toInt(dadosNotificacao[1]);
            double valor = toDouble(dadosNotificacao[2]);
            int quantidade = toInt(dadosNotificacao[3]);


            switch (acao)
            {
                case 0:
                    if (posicao > 0 && valor > 0 && quantidade > 0)
                    {
                        Oferta oferta = new Oferta(posicao, valor, quantidade);
                        ofertas.Add(oferta);
                    }
                    break;

                case 1:
                    try
                    {
                        var ofertaExiste = ofertas.First(o => o.getPosicao() == posicao);

                        if (ofertaExiste != null)
                        {
                            if (valor > 0)
                                ofertaExiste.setValor(valor);

                            if (quantidade > 0)
                                ofertaExiste.setQuantidade(quantidade);
                        }
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("A posição que deseja alterar não existe");
                        break;
                    }

                case 2:
                    ofertas.RemoveAll(o => o.getPosicao() == posicao);
                    break;
            }
        }

        Console.WriteLine("");

        BubbleSort(ofertas);
        List<Oferta> ordernarOfertas = ofertas.ToList();

        foreach (var oferta in ordernarOfertas)
        {
            Console.WriteLine($"{oferta.getPosicao()},{oferta.getValor()},{oferta.getQuantidade()}");
        }  
    }

    static void BubbleSort(List<Oferta> ofertas)
    {
        int qtdOfertas = ofertas.Count;

        for(int i = 0; i < qtdOfertas - 1; i++)
        {
            for (int j = 0; j < qtdOfertas - 1; j++)
            {
                if(ofertas[j].getPosicao() > ofertas[j+1].getPosicao())
                {
                    var aux = ofertas[j];
                    ofertas[j] = ofertas[j + 1];
                    ofertas[j+1] = aux;
                }
            }


        }
    }

    static int toInt(String numero)
    {
        return Int32.Parse(numero);
    }

    static double toDouble(String numero)
    {
        return Convert.ToDouble(numero);
    }




    class Oferta
    {
        private int posicao;
        private double valor;
        private int quantidade;


        public Oferta(int posicao, double valor, int quantidade)
        {
            this.posicao = posicao;
            this.valor = valor;
            this.quantidade = quantidade;
        }

        public int getPosicao()
        {
            return this.posicao;
        }

        public void setPosicao(int posicao)
        {
            this.posicao = posicao;
        }
        public double getValor()
        {
            return this.valor;
        }

        public void setValor(double valor)
        {
            this.valor = valor;
        }
        public int getQuantidade()
        {
            return quantidade;
        }

        public void setQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
        }
    }
}