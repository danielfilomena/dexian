import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { EscolaModel } from '../../../models/escola';
import { EscolaService } from '../../../services/escola.service';
import { AppSessionService } from '../../../services/app-session.service';

@Component({
  selector: 'app-escola-form',
  templateUrl: './escola-form.component.html',
  standalone: false,
  styleUrls: ['./escola-form.component.css']
})
export class EscolaFormComponent implements OnInit {

  @Output() onClose = new EventEmitter<void>();

  @ViewChild("form") form?: NgForm;

  escolaViewModel: EscolaModel = new EscolaModel();

  constructor(public bsModalRef: BsModalRef, private escolaService: EscolaService, private appSession: AppSessionService) { }

  ngOnInit() {

    this.buscarEscola();

  }

  onSave(){

    this.appSession.obterDadosSession().subscribe(result => {

      let token = result;
      this.escolaService.save(token!, this.escolaViewModel).subscribe(res => {
        this.onClose.emit();
        this.bsModalRef.hide();
      });
    });

  }

  buscarEscola() {

    this.escolaService.getIsNew().subscribe(result => {

      if(result > 0) {

        this.appSession.obterDadosSession().subscribe(res => {
          let token = res;

          this.escolaService.get(token!, result).subscribe(escola => {
            this.escolaViewModel = escola;
          });

        });

      }

    });

  }



}
