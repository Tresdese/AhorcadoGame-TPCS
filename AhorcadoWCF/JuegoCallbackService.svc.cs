using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AhorcadoWCF
{
    // Shell del servicio duplex (Tarea 0). La logica de juego en tiempo real
    // la implementa la Persona C. Por ahora compila y expone metadatos para
    // que el cliente pueda generar/consumir el proxy.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class JuegoCallbackService : IJuegoCallbackService
    {
        public void ConectarAlLobby(int idUsuario) => throw new NotImplementedException();

        public void DesconectarDelLobby(int idUsuario) => throw new NotImplementedException();

        public void UnirseASalaDePartida(int idPartida, int idUsuario) => throw new NotImplementedException();

        public void SalirDeSalaDePartida(int idPartida, int idUsuario) => throw new NotImplementedException();

        public void EnviarLetra(int idPartida, int idUsuario, char letra) => throw new NotImplementedException();

        public void EnviarMensajeChat(int idPartida, int idUsuario, string mensaje) => throw new NotImplementedException();

        public void NotificarAbandono(int idPartida, int idUsuario) => throw new NotImplementedException();
    }
}
