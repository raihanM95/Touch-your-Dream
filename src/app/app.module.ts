import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { AuthInterceptor } from './auth/auth.interceptor';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppHeaderComponent } from './_layout/app-header/app-header.component';
import { FooterComponent } from './_layout/footer/footer.component';
import { AppLayoutComponent } from './_layout/app-layout/app-layout.component';
import { AdminHeaderComponent } from './_layout/admin-header/admin-header.component';
import { AdminLayoutComponent } from './_layout/admin-layout/admin-layout.component';
import { AdvisorHeaderComponent } from './_layout/advisor-header/advisor-header.component';
import { StudentHeaderComponent } from './_layout/student-header/student-header.component';

import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { SubjectComponent } from './subject/subject.component';

import { AdminService } from './shared/admin.service';

import { AloginComponent } from './admin/alogin/alogin.component';
import { AhomeComponent } from './admin/ahome/ahome.component';
import { AdvisorListComponent } from './admin/advisor-list/advisor-list.component';
import { AdvisorDetailsComponent } from './admin/advisor-list/advisor-details/advisor-details.component';
import { StudentListComponent } from './admin/student-list/student-list.component';
import { StudentDetailsComponent } from './admin/student-list/student-details/student-details.component';
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

@NgModule({
  declarations: [
    AppComponent,
    AppHeaderComponent,
    FooterComponent,
    AppLayoutComponent,
    AdminHeaderComponent,
    AdminLayoutComponent,
    StudentHeaderComponent,
    AdvisorHeaderComponent,

    HomeComponent,
    AboutComponent,
    ContactComponent,
    SubjectComponent,

    AloginComponent,
    AhomeComponent,
    AdvisorListComponent,
    AdvisorDetailsComponent,
    StudentListComponent,
    StudentDetailsComponent,
    RpaperListComponent,
    EntrysubinfoComponent,
    EntryreqcgpaComponent,
    EntryreqskillComponent,
    EntrysoinfoComponent,

    TregisterComponent,
    TloginComponent,
    TprofileComponent,

    SregisterComponent,
    SloginComponent,
    SprofileComponent,
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
  ],
  providers: [AdminService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
