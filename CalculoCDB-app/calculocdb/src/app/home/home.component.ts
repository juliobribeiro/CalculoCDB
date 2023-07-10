import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { Rendimento } from '../interface/rendimento';
import { Resgate } from '../interface/resgate';
import { ResgateService } from '../services/resgate.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {

  public frmRendimento!: FormGroup;
  public valorBruto!: string;
  public valorLiquido!: string;
  public resgate = new Resgate();

  public mensagemErro: string;

  constructor(private resgateService: ResgateService) { }

  ngOnInit() {
    this.frmRendimento = new FormGroup({
      txtValor: new FormControl(''),
      txtPrazo: new FormControl('')
    });
  }

  calcular() {

    this.mensagemErro = null;

    if (this.frmRendimento.controls['txtPrazo'].value <= 1) {
      this.mensagemErro = "O campo Prazo deve ser maior que 1 para resgate."
      return
    }

    if (this.frmRendimento.controls['txtValor'].value <= 0) {
      this.mensagemErro = "O campo Valor deve ser monetário positivo."
      return
    }


    this.resgateService.calcular(new Rendimento(this.frmRendimento.controls['txtPrazo'].value,
      this.frmRendimento.controls['txtValor'].value))
      .subscribe(resgate => {
        this.resgate = resgate
      })
  }

}


