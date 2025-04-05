import { Component, OnInit } from '@angular/core';
import { AppSessionService } from '../../services/app-session.service';
import { EscolaService } from '../../services/escola.service';
import { EscolaModel } from '../../models/escola';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { EscolaFormComponent } from './escola-form/escola-form.component';


@Component({
  selector: 'app-escola',
  templateUrl: './escola.component.html',
  standalone: false,
  styleUrls: ['./escola.component.css']
})
export class EscolaComponent implements OnInit {

  bsModalRef?: BsModalRef;

  escolas: EscolaModel[] = [];
  filtro!: string;

  constructor(private escolaService: EscolaService, private appSession: AppSessionService, private modalService: BsModalService) { }

  ngOnInit() {

    this.buscarEscolas();

  }

  buscarEscolas() {

    this.appSession.obterDadosSession().subscribe(result => {

      const token = result;

      this.escolaService.list(token!).subscribe( res => {
        this.escolas = res;
      });

    });

  }

  onNew() {

    this.escolaService.setIsNew(0);

    this.bsModalRef = this.modalService.show(EscolaFormComponent, {
      backdrop: 'static',
      keyboard: false,
      class: 'modal-dialog-centered'
    });

    const content = this.bsModalRef.content;

    if(content && content.onClose) {
      content.onClose.subscribe(() => {
        this.buscarEscolas();
      });
    }

  }

  onUpdate(id: number) {

    this.escolaService.setIsNew(id);

    this.bsModalRef = this.modalService.show(EscolaFormComponent, {
      backdrop: 'static',
      keyboard: false,
      class: 'modal-dialog-centered'
    });

    const content = this.bsModalRef.content;

    if(content && content.onClose) {
      content.onClose.subscribe(() => {
        this.buscarEscolas();
      });
    }

  }

  onDelete(id: number) {

    this.appSession.obterDadosSession().subscribe(result => {
      let token = result;

      this.escolaService.delete(token!, id).subscribe(res => {
        this.buscarEscolas();
      });

    });

  }

  onSearch() {

    if(this.filtro.length > 0) {
      this.escolas = this.escolas.filter(item => item.sDescricao?.toLowerCase().includes(this.filtro?.toLowerCase()));
    }
    else
    {
      this.buscarEscolas();
    }


  }

}
