import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';

import { AppLayoutComponent } from './_layout/app-layout/app-layout.component';
import { AdminHeaderComponent } from './_layout/admin-header/admin-header.component';
import { AdvisorHeaderComponent } from './_layout/advisor-header/advisor-header.component';
import { StudentHeaderComponent } from './_layout/student-header/student-header.component';

import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { SubjectComponent } from './subject/subject.component';

import { AloginComponent } from './admin/alogin/alogin.component';
import { AhomeComponent } from './admin/ahome/ahome.component';
import { AdvisorListComponent } from './admin/advisor-list/advisor-list.component';
import { StudentListComponent } from './admin/student-list/student-list.component';
import { RpaperListComponent } from './admin/rpaper-list/rpaper-list.component';
import { EntrysubinfoComponent } from './admin/entrysubinfo/entrysubinfo.component';
import { EntryreqcgpaComponent } from './admin/entryreqcgpa/entryreqcgpa.component';
import { EntryreqskillComponent } from './admin/entryreqskill/entryreqskill.component';
import { EntrysoinfoComponent } from './admin/entrysoinfo/entrysoinfo.component';

import { TregisterComponent } from './advisor/tregister/tregister.component';
import { TloginComponent } from './advisor/tlogin/tlogin.component';
import { TprofileComponent } from './advisor/tprofile/tprofile.component';

import { SregisterComponent } from './student/sregister/sregister.component';
import { SloginComponent } from './student/slogin/slogin.component';
import { SprofileComponent } from './student/sprofile/sprofile.component';

const routes: Routes = [
  // site with layout routes
  { 
    path: '', 
    component: AppLayoutComponent,
    children: [
      { path: '', component: HomeComponent, pathMatch: 'full'},
      { path: 'about', component: AboutComponent },
      { path: 'contact', component: ContactComponent },
      { path: 'subject', component: SubjectComponent }
    ]
  },

  // no layout routes
  { path: 'admin/alogin', component: AloginComponent, pathMatch: 'full' },
  { path: 'tregister', component: TregisterComponent, pathMatch: 'full' },
  { path: 'tlogin', component: TloginComponent, pathMatch: 'full' },
  { path: 'sregister', component: SregisterComponent, pathMatch: 'full' },
  { path: 'slogin', component: SloginComponent, pathMatch: 'full' },

  // admin site with layout routes
  { 
    path: '', 
    component: AdminHeaderComponent,
    children: [
      { path: 'ahome', component: AhomeComponent, pathMatch: 'full', canActivate:[AuthGuard]},
      { path: 'advisor-list', component: AdvisorListComponent, pathMatch: 'full', canActivate:[AuthGuard]},
      { path: 'student-list', component: StudentListComponent, pathMatch: 'full', canActivate:[AuthGuard]},
      { path: 'rpaper-list', component: RpaperListComponent, pathMatch: 'full', canActivate:[AuthGuard]},
      { path: 'entrysubinfo', component: EntrysubinfoComponent, pathMatch: 'full', canActivate:[AuthGuard]},
      { path: 'entryreqcgpa', component: EntryreqcgpaComponent, pathMatch: 'full', canActivate:[AuthGuard]},
      { path: 'entryreqskill', component: EntryreqskillComponent, pathMatch: 'full', canActivate:[AuthGuard]},
      { path: 'entrysoinfo', component: EntrysoinfoComponent, pathMatch: 'full', canActivate:[AuthGuard]},
    ]
  },

  // advisor site with layout routes
  { 
    path: '', 
    component: AdvisorHeaderComponent,
    children: [
      { path: 'tprofile', component: TprofileComponent, pathMatch: 'full', canActivate:[AuthGuard]},
      
    ]
  },

  // student site with layout routes
  { 
    path: '', 
    component: StudentHeaderComponent,
    children: [
      { path: 'sprofile', component: SprofileComponent, pathMatch: 'full', canActivate:[AuthGuard]},
      
    ]
  },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
