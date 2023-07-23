import { Button } from "primereact/button";
import { Column } from "primereact/column";
import { DataTable } from "primereact/datatable";
import { Dialog } from "primereact/dialog";
import { FileUpload } from "primereact/fileupload";
import { InputNumber } from "primereact/inputnumber";
import { InputText } from "primereact/inputtext";
import { InputTextarea } from "primereact/inputtextarea";
import { RadioButton } from "primereact/radiobutton";
import { Rating } from "primereact/rating";
import { Toast } from "primereact/toast";
import { Toolbar } from "primereact/toolbar";
import { classNames } from "primereact/utils";
import React, { useEffect, useRef, useState } from "react";
import { Checkbox } from "primereact/checkbox";
import { Dropdown } from "primereact/dropdown";
import { Password } from "primereact/password";


import { ManagerService } from "../service/service";
import * as Utils from "../service/util";

const Crud = () => {
  let emptyAdmin = {
    id: null,
    emailAddress: "",
    password: "",
    updatePassword: false,
    roleId: -1,
  };

  const [roles, setRoles] = useState(null);
  const [admins, setAdmins] = useState(null);

  const [admin, setAdmin] = useState(emptyAdmin);
  const [submitted, setSubmitted] = useState(false);
  const [globalFilter, setGlobalFilter] = useState(null);

  const [updatePassword, setUpdatePassword] = useState(false);

  const [updateOrAddDialogShow, setUpdateOrAddDialogShow] = useState(false);
  const [dialogAction, setDialogAction] = useState("none");
  const [dialogShow, setDialogShow] = useState(false);

  const toast = useRef(null);
  const dt = useRef(null);

  const fetchAdmins = async () => {
    var result = await ManagerService.getAdminList();
    if (!result) return;
    setAdmins(result);
  };
  const fectRoles = async () => {
    var result = await ManagerService.getRoles();
    if (!result) return;
    console.log(result);
    var mapped = result.map((item) => {
      return {
        label: item.name,
        value: item.id,
      };
    });
    setRoles(mapped);
  };
  useEffect(() => {
    fetchAdmins();
    fectRoles();
  }, []);


  const exportCSV = () => {
    dt.current.exportCSV();
  };

  const onInputChange = (e, name) => {
    const val = (e.target && e.target.value) || "";
    let _admin = { ...admin };
    _admin[`${name}`] = val;

    setAdmin(_admin);
  };

  const onInputNumberChange = (e, name) => {
    const val = e.value || 0;
    let _admin = { ...admin };
    _admin[`${name}`] = val;

    setAdmin(_admin);
  };

  const leftToolbarTemplate = () => {
    return (
      <React.Fragment>
        <div className="my-2">
          <Button
            label="New"
            icon="pi pi-plus"
            severity="sucess"
            className="mr-2"
            onClick={() => showDialog(emptyAdmin, "create")}
          />
        </div>
      </React.Fragment>
    );
  };

  const rightToolbarTemplate = () => {
    return (
      <React.Fragment>
        <Button
          label="Export CSV"
          icon="pi pi-upload"
          severity="help"
          className="mr-2"

          onClick={exportCSV}
        />
        
      </React.Fragment>
      
    );
  };

  const rowActionBodyTemplate = (rowData) => {
    var isDeleted = rowData.deletedDate != null;
    return (
      <>
        <Button
          icon="pi pi-pencil"
          visible={!isDeleted}
          severity="success"
          tooltip="Edit"
          className="mr-2"
          tooltipOptions={{ position: "bottom" }}
          onClick={() => showDialog(rowData, "update")}
        />
        <Button
          icon="pi pi-trash"
          visible={!isDeleted}
          severity="danger"
          tooltip="Delete"
          className="mr-2"
          tooltipOptions={{ position: "bottom" }}
          onClick={() => showDialog(rowData, "delete")}
        />
        <Button
          icon="pi pi-check"
          visible={isDeleted}
          severity="info"
          tooltip="Recover"
          className="mr-2"
          tooltipOptions={{ position: "bottom" }}
          onClick={() => showDialog(rowData, "recover")}
        />
      </>
    );
  };

  const tableHeader = (
    <div className="flex flex-column md:flex-row md:justify-content-between md:align-items-center">
      <h5 className="m-0">Manage Admins</h5>
      <span className="block mt-2 md:mt-0 p-input-icon-left">
        <i className="pi pi-search" />
        <InputText
          type="search"
          onChange={(e) => setGlobalFilter(e.target.value)}
          placeholder="Search..."
        />
      </span>
    </div>
  );



  const DDEHideDialog = () => {
    // console.log(admin);
    // console.log(dialogAction);
    if (dialogAction == "update" || dialogAction == "create") {
      setSubmitted(false);
      setUpdateOrAddDialogShow(false);
    } else {
      setDialogShow(false);
    }
    setAdmin(emptyAdmin);
    setDialogAction("none");
  };

  const showDialog = (model, action) => {
    setAdmin(model);
    setDialogAction(action);
    if (action == "update") {
      setSubmitted(false);
      setUpdateOrAddDialogShow(true);
      setUpdatePassword(false);
      return;
    }
    if (action == "create") {
      setUpdateOrAddDialogShow(true);
      setUpdatePassword(true);
      setSubmitted(false);
      return;
    }
    setDialogShow(true);
  };
  const simpleAdminDialogFooter = (
    <>
      <Button label="No" icon="pi pi-times" text onClick={DDEHideDialog} />
      <Button label="Yes" icon="pi pi-check" text onClick={DDEConfirmDialog} />
    </>
  );
  const formDialogFooter = (
    <>
      <Button
        label="Cancel"
        icon="pi pi-times"
        text
        onClick={DDEHideDialog}
      />
      <Button label="Save" icon="pi pi-check" text onClick={DDEConfirmDialog} />
    </>
  );
  async function DDEConfirmDialog(e) {
    //Disable Delete Enable
    let result;
    console.log(dialogAction);
    switch (dialogAction) {
      case "delete":
        result = await ManagerService.deleteAdmin(admin.id);
        break;
      case "recover":
        result = await ManagerService.recoverAdmin(admin.id);
        break;
      case "update":
        setSubmitted(true);
        var body = {
          emailAddress: admin.emailAddress,
          password: admin.password,
          roleId: admin.roleId,
          updatePassword: updatePassword,
          id : admin.id
        };
        result = await ManagerService.updateAdmin(body);
        break;
      case "create":
        setSubmitted(true);
        var body = {
          emailAddress: admin.emailAddress,
          password: admin.password,
          roleId: admin.roleId,
        };
        result = await ManagerService.createAdmin(body);
        break;
      default:
        toast.current.show({
          severity: "warn",
          summary: "Warning",
          detail: "Invalid Action",
          life: 2000,
        });
        return;
    }

    if (result.status) {
      setAdmin(emptyAdmin);
      setDialogShow(false);
      setUpdateOrAddDialogShow(false);
      fetchAdmins();
      toast.current.show({
        severity: "success",
        summary: "Successful",
        detail: result.message,
        life: 2000,
      });
      return;
    }
    toast.current.show({
      severity: "error",
      summary: "Failed",
      detail: result.message,
      life: 2000,
    });
  }

  const registerDateBodyTemplate = (rowData) => {
    return <>{Utils.formatDateTime(rowData.registerDate)}</>;
  };
  const deletedDateBodyTemplate = (rowData) => {
    return <>{Utils.formatDateTime(rowData.deletedDate)}</>;
  };
  return (
    <div className="grid crud-demo">
      <div className="col-12">
        <div className="card">
          <Toast ref={toast} />
          <Toolbar
            className="mb-4"
            start={leftToolbarTemplate}
            end={rightToolbarTemplate}
          ></Toolbar>

          <DataTable
            ref={dt}
            value={admins}
            dataKey="id"
            paginator
            rows={10}
            rowsPerPageOptions={[5, 10, 25]}
            className="datatable-responsive"
            paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
            currentPageReportTemplate="Showing {first} to {last} of {totalRecords} admins"
            globalFilter={globalFilter}
            emptyMessage="No admins found."
            header={tableHeader}
            responsiveLayout="scroll"
          >
            <Column
              field="registerDate"
              header="RegisterDate"
              sortable
              headerStyle={{ minWidth: "15rem" }}
              body={registerDateBodyTemplate}
            ></Column>
            <Column
              field="emailAddress"
              header="EmailAddress"
              sortable
              headerStyle={{ minWidth: "15rem" }}
            ></Column>
            <Column
              field="roleName"
              header="Role"
              sortable
              headerStyle={{ minWidth: "15rem" }}
            ></Column>
            <Column
              field="DeletedDate"
              header="DeletedDate"
              sortable
              headerStyle={{ minWidth: "15rem" }}
              body={deletedDateBodyTemplate}

            ></Column>
            
            <Column
              body={rowActionBodyTemplate}
              headerStyle={{ minWidth: "10rem" }}
            ></Column>
          </DataTable>

          <Dialog
            visible={updateOrAddDialogShow}
            style={{ width: "450px" }}
            header="Admin Details"
            modal
            className="p-fluid"
            footer={formDialogFooter}
            onHide={DDEHideDialog}
          >
            <div className="field">
              <label htmlFor="emailAddress">EmailAddress</label>
              <InputText
                id="emailAddress"
                keyfilter="email"
                value={admin.emailAddress}
                onChange={(e) => onInputChange(e, "emailAddress")}
                required
              />
            </div>

            <div className="field">
              <label htmlFor="password">Password</label>
              <div className="p-inputgroup">
                <span className="p-inputgroup-addon">
                  <Checkbox
                    inputId="updatePassword"
                    id="updatePassword"
                    checked={updatePassword}
                    disabled={dialogAction === "update" ? false : true}
                    onChange={(e) => setUpdatePassword(e.checked)}
                  />
                </span>
                <Password
                  id="password"
                  disabled={!updatePassword}
                  value={admin.password}
                  toggleMask
                  promptLabel="Choose a password"
                  weakLabel="Too simple"
                  mediumLabel="Average complexity"
                  strongLabel="Complex password"
                  onChange={(e) => onInputChange(e, "password")}
                  required
                />
              </div>
            </div>

            <div className="field">
              <label htmlFor="roleId">Role</label>

              <Dropdown
                value={admin.roleId}
                onChange={(e) => onInputChange(e, "roleId")}
                options={roles}
                optionValue="value"
                optionLabel="label"
                placeholder="Select a Role"
                className="w-full md:w-14rem"
                required
              />
            </div>
          </Dialog>

          <Dialog
            visible={dialogShow}
            style={{ width: "500px" }}
            header="Confirm"
            modal
            footer={simpleAdminDialogFooter}
            onHide={DDEHideDialog}
          >
            <div className="flex align-items-center justify-content-center">
              <i
                className="pi pi-exclamation-triangle mr-3"
                style={{ fontSize: "2rem" }}
              />
              {admin && (
                <span>
                  Are you sure you want to {dialogAction}
                  <b> {admin.emailAddress}</b> account ?
                </span>
              )}
            </div>
          </Dialog>
        </div>
      </div>
    </div>
  );
};

export default Crud;
