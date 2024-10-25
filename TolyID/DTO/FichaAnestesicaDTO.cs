using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TolyID.MVVM.Models;  // Supondo que ParametroFisiologico esteja neste namespace

namespace TolyID.DTO
{
    public class FichaAnestesicaDTO
    {
        [JsonProperty("tipoAnestesicoOuDose")]
        public string? TipoAnestesicoOuDose { get; set; }

        [JsonProperty("viaDeAdministracao")]
        public string? ViaDeAdministracao { get; set; }

        [JsonProperty("aplicacao")]
        public TimeSpan Aplicacao { get; set; }

        [JsonProperty("inducao")]
        public TimeSpan Inducao { get; set; }

        [JsonProperty("retorno")]
        public TimeSpan Retorno { get; set; }

        [JsonProperty("parametrosFisiologicos")]
        public List<ParametroFisiologico> ParametrosFisiologicos { get; set; }

        // Construtor mapeando as propriedades do modelo Anestesia para o DTO
        public FichaAnestesicaDTO(FichaAnestesica anestesia)
        {
            TipoAnestesicoOuDose = anestesia.TipoAnestesicoOuDose;
            ViaDeAdministracao = anestesia.ViaDeAdministracao;
            Aplicacao = anestesia.Aplicacao;
            Inducao = anestesia.Inducao;
            Retorno = anestesia.Retorno;
            ParametrosFisiologicos = anestesia.ParametrosFisiologicos;
        }
    }
}
