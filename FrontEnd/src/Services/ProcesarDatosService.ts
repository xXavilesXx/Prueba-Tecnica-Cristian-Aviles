import api from "./api";

import type { GirarRuletaDto } from "../Models/GirarRuletaDto";
import type { RespuestaDto } from "../Models/RespuestaDto";
import type { USUARIOSXMONTO } from "../Models/USUARIOSXMONTO";
import type { UsuarioDto } from "../Models/UsuarioDto";

class ProcesarDatosService {
  async girarRuleta(dto: GirarRuletaDto): Promise<RespuestaDto> {
    const { data } = await api.post<RespuestaDto>("/GirarRuleta/Girar",dto);
    return data;
  }

  async GuardarDatos(Model: USUARIOSXMONTO):Promise<boolean>{
    const {data}= await api.post<boolean>("/UsuarioXMonto/Insertar",Model);
    return data;
  }

  async ObtenerSaldo(dto: UsuarioDto):Promise<USUARIOSXMONTO>{
    const {data}= await api.post<USUARIOSXMONTO>("/CargarSaldo/Obtener",dto);
    return data;
  }

}

export default ProcesarDatosService;