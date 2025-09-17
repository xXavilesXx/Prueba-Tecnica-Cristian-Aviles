<template>
  <div class="container">
    <h1>🎰 Ruleta</h1>

    
      <div class="d-grid gap-3">
        <input v-model="nombre" class="form-control" placeholder="Nombre" />
        <div>
          <label class="form-label">Selecciona tipo de juego</label>
          <select v-model="tipoApuesta" class="form-select" aria-label="Default select example">
            <option value="color">Color</option>
            <option value="parimpar">Par/Impar</option>
            <option value="numero">Número + Color</option>
          </select>
        </div>
        <!-- Inputs que aparecen según la opción seleccionada -->
        <div v-if="tipoApuesta === 'color'">
          <label class="form-label">Selecciona color</label>
          <select v-model="color" class="form-select">
            <option value="rojo">Rojo</option>
            <option value="negro">Negro</option>
          </select>
        </div>
        <div v-else-if="tipoApuesta === 'parimpar'">
          <label class="form-label">Selecciona color</label>
          <select v-model="color" class="form-select mb-2">
            <option value="rojo">Rojo</option>
            <option value="negro">Negro</option>
          </select>

          <label class="form-label">Selecciona Par o Impar</label>
          <select v-model="paridad" class="form-select">
            <option value="par">Par</option>
            <option value="impar">Impar</option>
          </select>
        </div>
        <div v-else-if="tipoApuesta === 'numero'">
          <label class="form-label">Número (0 - 36)</label>
          <input type="number" v-model.number="numero" class="form-control mb-2" min="0" max="36" />

          <label class="form-label">Color</label>
          <select v-model="color" class="form-select">
            <option value="rojo">Rojo</option>
            <option value="negro">Negro</option>
          </select>
        </div>
        <input v-model.number="saldo" class="form-control" type="number" placeholder="Saldo inicial" />
        <button class="btn btn-success" @click="girarRuleta()">Iniciar Juego</button>
        <button class="btn btn-success" @click="guardarDatos()">Guardar</button>
        <button class="btn btn-primary" @click="ObtenerSaldo()">Cargar saldo</button>

      </div>

    </div>

  
</template>

<style>
.container {
  font-family: Arial, sans-serif;
  padding: 20px;
}
</style>

<script setup lang="ts">
import { computed, ref } from 'vue'
import ProcesarDatosService from "./Services/ProcesarDatosService";
import type {GirarRuletaDto} from "./Models/GirarRuletaDto";
import type { RespuestaDto }  from "./Models/RespuestaDto";
import type { USUARIOSXMONTO } from './Models/USUARIOSXMONTO';
import type { UsuarioDto } from './Models/UsuarioDto';

// Estado del jugador
const nombre = ref('')
const color = ref('')
const paridad = ref('')
const tipoApuesta = ref('') // puede ser 'color', 'parimpar', 'numero'
const numero = ref(0)
const saldo = ref<number>(0)

const service = new ProcesarDatosService();
const resultado = ref<RespuestaDto | null>(null);

const apuesta = computed<GirarRuletaDto>(() => ({
  Nombre: nombre.value,
  Saldo: saldo.value,
  TipoJuego: tipoApuesta.value,
  Color: color.value,
  ParImpar: paridad.value,
  Numero: numero.value,
}));

async function girarRuleta() {
  try {
    const data = await service.girarRuleta(apuesta.value);
    resultado.value = data;
    saldo.value = resultado.value?.saldo;
    if (resultado.value.gano === "Gano") {
      alert(`¡Felicidades ${resultado.value.nombre}! Ganaste.`);
    } else {
      alert(`Lo siento ${resultado.value.nombre}, perdiste.`);
    }
  } catch (error)
  {
   alert('Error');
  }
};

const UsuXMonto = computed<USUARIOSXMONTO>(() => ({
  USUARIO: nombre.value,
  MONTO: saldo.value,
}));

async function guardarDatos() {
  try{

    const data = await service.GuardarDatos(UsuXMonto.value);
    const SeGuardo:boolean = data;
    if(SeGuardo){
      alert(`Se guardó correctamente.`);
    }else{
      alert(`No se pudo guardar.`);
    }
  }catch(error){
    alert('Error');
  }
};

const Usuario = computed<UsuarioDto>(() => ({
  Usuario: nombre.value
}));

const resultadoSaldo = ref<USUARIOSXMONTO | null>(null);

async function ObtenerSaldo() {
  
  try{
    const data = await service.ObtenerSaldo(Usuario.value);
    resultadoSaldo.value = data;
    if(resultadoSaldo.value.monto != null){
      saldo.value = resultadoSaldo.value?.monto;
      alert(`Trajo la información correctamente.`);
    }else{
      alert(`No existe información.`);
    }
  }catch(error){
    alert('Error');
  }
};

</script>
