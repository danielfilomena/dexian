import { Component, OnInit } from '@angular/core';
import { AlunoFormComponent } from './aluno-form/aluno-form.component';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AlunoModel } from '../../models/aluno';
import { AlunoService } from '../../services/aluno.service';
import { AppSessionService } from '../../services/app-session.service';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  standalone: false,
  styleUrls: ['./aluno.component.css']
})
export class AlunoComponent implements OnInit {

  bsModalRef?: BsModalRef;

  alunos: AlunoModel[] = [];
  filtro!: string;

  constructor(private alunoService: AlunoService, private appSession: AppSessionService, private modalService: BsModalService) { }

  ngOnInit() {

    this.buscarAlunos();

  }

  buscarAlunos() {

      this.appSession.obterDadosSession().subscribe(result => {

        const token = result;

        this.alunoService.list(token!).subscribe( res => {
          this.alunos = res;
        });

      });

    }

    onNew() {

      this.alunoService.setIsNew(0);

      this.bsModalRef = this.modalService.show(AlunoFormComponent, {
        backdrop: 'static',
        keyboard: false,
        class: 'modal-dialog-centered'
      });

      const content = this.bsModalRef.content;

      if(content && content.onClose) {
        content.onClose.subscribe(() => {
          this.buscarAlunos();
        });
      }

    }

    onUpdate(id: number) {

      this.alunoService.setIsNew(id);

      this.bsModalRef = this.modalService.show(AlunoFormComponent, {
        backdrop: 'static',
        keyboard: false,
        class: 'modal-dialog-centered'
      });

      const content = this.bsModalRef.content;

      if(content && content.onClose) {
        content.onClose.subscribe(() => {
          this.buscarAlunos();
        });
      }

    }

    onDelete(id: number) {

      this.appSession.obterDadosSession().subscribe(result => {
        let token = result;

        this.alunoService.delete(token!, id).subscribe(res => {
          this.buscarAlunos();
        });

      });

    }

    onSearch(){

      if(this.filtro.length > 0){

        this.alunos = this.alunos.filter(x => x.sNome?.toLocaleLowerCase() == this.filtro.toLocaleLowerCase() || x.sCPF.toLocaleLowerCase() == this.filtro.toLocaleLowerCase())

      }
      else
      {
        this.buscarAlunos();
      }

    }

}
