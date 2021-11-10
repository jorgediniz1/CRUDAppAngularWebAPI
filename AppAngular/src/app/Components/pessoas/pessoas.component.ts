import {enableProdMode} from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pessoa } from 'src/app/Pessoa';
import { PessoasService } from 'src/app/pessoas.service';

enableProdMode();

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrls: ['./pessoas.component.css']
})
export class PessoasComponent implements OnInit {

  formulario: any;
  tituloFormulario: any;
  //pessoas: Pessoa[] = []; 
  
  
  constructor(private pessoasService:PessoasService) { }

  ngOnInit(): void {
    
  //  this.pessoasService.PegarTodos().subscribe(resultado => {
    //  this.pessoas = resultado;
    //})

    this.tituloFormulario = 'Nova Pessoa';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      sobrenome: new FormControl(null),
      idade: new FormControl(null),
      profissao: new FormControl(null)
    });  
  }
  EnviarFormulario(): void {
    const pessoa : Pessoa = this.formulario.value;
    this.pessoasService.SalvarPessoa(pessoa).subscribe((resultado) =>{
      alert('Pessoa inserida com sucesso');
    });
  }

}
