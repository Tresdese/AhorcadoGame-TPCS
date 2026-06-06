using System.Collections.Generic;
using System.ServiceModel;

namespace AhorcadoWCF
{
    public interface IJuegoCallback
    {
        [OperationContract(IsOneWay = true)]
        void PartidaCreada(PartidaDTO partida);

        [OperationContract(IsOneWay = true)]
        void PartidaRemovidaDelLobby(int idPartida);

        [OperationContract(IsOneWay = true)]
        void AdivinadorSeUnio(UsuarioDTO adivinador);

        [OperationContract(IsOneWay = true)]
        void PalabraSeleccionada(int longitud, string descripcion, string categoria);

        [OperationContract(IsOneWay = true)]
        void LetraIngresada(char letra, bool acerto, List<int> posiciones, int intentosRestantes);

        [OperationContract(IsOneWay = true)]
        void MensajeChatRecibido(string remitente, string mensaje);

        [OperationContract(IsOneWay = true)]
        void RivalAbandono(string nombreRival);

        [OperationContract(IsOneWay = true)]
        void PartidaFinalizada(string resultado, string palabra, int puntosObtenidos, int puntajeGlobal);
    }

    [ServiceContract(CallbackContract = typeof(IJuegoCallback))]
    
    public interface IJuegoCallbackService
    {
        [OperationContract(IsOneWay = true)]
        void ConectarAlLobby(int idUsuario);

        [OperationContract(IsOneWay = true)]
        void DesconectarDelLobby(int idUsuario);

        [OperationContract(IsOneWay = true)]
        void UnirseASalaDePartida(int idPartida, int idUsuario);

        [OperationContract(IsOneWay = true)]
        void SalirDeSalaDePartida(int idPartida, int idUsuario);

        [OperationContract(IsOneWay = true)]
        void EnviarLetra(int idPartida, int idUsuario, char letra);

        [OperationContract(IsOneWay = true)]
        void EnviarMensajeChat(int idPartida, int idUsuario, string mensaje);

        [OperationContract(IsOneWay = true)]
        void NotificarAbandono(int idPartida, int idUsuario);
    }
}
