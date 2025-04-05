import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

import { BsModalRef } from 'ngx-bootstrap/modal';

import { AlunoModel } from '../../../models/aluno';
import { AlunoService } from '../../../services/aluno.service';
import { AppSessionService } from '../../../services/app-session.service';
import { EscolaService } from '../../../services/escola.service';
import { EscolaModel } from '../../../models/escola';

@Component({
  selector: 'app-aluno-form',
  templateUrl: './aluno-form.component.html',
  standalone: false,
  styleUrls: ['./aluno-form.component.css']
})
export class AlunoFormComponent implements OnInit {

  @Output() onClose = new EventEmitter<void>();
  @ViewChild("form") form?: NgForm;

  escolas: EscolaModel[] = [];

  alunoViewModel: AlunoModel = new AlunoModel();

  constructor(public bsModalRef: BsModalRef, private alunoService: AlunoService, private appSession: AppSessionService, private escolaService: EscolaService) { }

  ngOnInit() {

    this.buscarAlunos();
    this.buscarEscolas();

  }

  onSave(){

    this.appSession.obterDadosSession().subscribe(result => {

      let token = result;
      this.alunoService.save(token!, this.alunoViewModel).subscribe(res => {
        this.onClose.emit();
        this.bsModalRef.hide();
      });
    });

  }

  buscarAlunos() {

    this.alunoService.getIsNew().subscribe(result => {

      if(result > 0) {

        this.appSession.obterDadosSession().subscribe(res => {
          let token = res;

          this.alunoService.get(token!, result).subscribe(aluno => {
            this.alunoViewModel = aluno;
          });

        });

      }

    });

  }

  buscarEscolas() {

    this.appSession.obterDadosSession().subscribe(res => {
      let token = res;

      this.escolaService.list(token!).subscribe(result => {
        this.escolas = result;
      })

    })

  }

}
