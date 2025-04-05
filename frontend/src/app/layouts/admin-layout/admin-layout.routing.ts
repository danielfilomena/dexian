import { Routes } from '@angular/router';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { AuthGuard } from '../../services/auth-guard.service';
import { EscolaComponent } from '../../pages/escola/escola.component';
import { AlunoComponent } from '../../pages/aluno/aluno.component';

export const AdminLayoutRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "dashboard",
        component: DashboardComponent,
        canActivate: [AuthGuard]

      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "escola",
        component: EscolaComponent,
        canActivate: [AuthGuard]
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "aluno",
        component: AlunoComponent,
        canActivate: [AuthGuard]
      }
    ]
  }

];
