using MeuPrimeiroAppXamarin.Classes;
using MeuPrimeiroAppXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        //url da api para salvar o agendamento
        const string URL_SALVA_AGENDAMENTPO = "http://aluracar.herokuapp.com/salvaragendamento";

        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo
        {
            get { return Agendamento.Veiculo; }
            set { Agendamento.Veiculo = value; }
        }

        public string Nome
        {
            get { return Agendamento.Nome; }
            set 
            { 
                Agendamento.Nome = value;

                /*avisa ao form que houve alteração de valor para habilitar ou nao o botao*/
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute(); 
            }
        }
        public int Idade
        {
            get { return Agendamento.Idade; }
            set { Agendamento.Idade = value; }
        }
        public string Cpf
        {
            get { return Agendamento.Cpf; }
            set 
            { 
                Agendamento.Cpf = value;

                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Telefone
        {
            get { return Agendamento.Telefone; }
            set 
            { 
                Agendamento.Telefone = value;

                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Email
        {
            get { return Agendamento.Email; }
            set 
            { 
                Agendamento.Email = value;

                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }

        public DateTime DataAgendamento
        {
            get { return Agendamento.DataAgendamento; }
            set { Agendamento.DataAgendamento = value; }
        }
        public TimeSpan HoraAgendamento
        {
            get { return Agendamento.HoraAgendamento; }
            set { Agendamento.HoraAgendamento = value; }
        }

        public ICommand AgendarCommand { get; set; }

        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
            this.DataAgendamento = DateTime.Today;
            this.HoraAgendamento = DateTime.Now.TimeOfDay;
            this.AgendarCommand = new Command(()=>
            {
                //envia mensagem do tipo do modelo que está sendo utilizado
                MessagingCenter.Send<Agendamento>(this.Agendamento, "Agendamento");            
            }, ()=> 
            {
                //validacao dos campos, não podem ser nulos ou vazios
                return !string.IsNullOrEmpty(this.Nome)
                && !string.IsNullOrEmpty(this.Telefone)
                && !string.IsNullOrEmpty(this.Email);
                //colocar cpf e idade aqui futuramente na api personalizada
            });
        }

        //responsável por enviar o agendamento (post)
        public async void SalvarAgendamento()
        {
            /*cliente http responsável por enviar e receber respostas HTTP*/
            HttpClient cliente = new HttpClient();

            //concatena data e hora
            var dataHoraAgendamento = new DateTime(
                DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds);

            //passando para a string json os dados do agendamento
            var json = JsonConvert.SerializeObject(new
            {
                nome = this.Nome,
                fone = this.Telefone,
                //colocar cpf e idade aqui futuramente na api personalizada
                email = this.Email,
                carro = this.Veiculo.Nome,
                preco = this.Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento,
            }); 

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json"); /*conteudo que será passado para a api*/
            var respostaPost = await cliente.PostAsync(URL_SALVA_AGENDAMENTPO, conteudo); /*acessa e url de post para enviar as informações e recebe resposta*/

            //em caso de sucesso da requisição envie uma mensagem pelo MessagingCenter
            if (respostaPost.IsSuccessStatusCode)
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            }
        }
    }
}
