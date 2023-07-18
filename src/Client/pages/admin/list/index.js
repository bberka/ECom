import { Button } from 'primereact/button';
import { Column } from 'primereact/column';
import { DataTable } from 'primereact/datatable';
import { Dialog } from 'primereact/dialog';
import { FileUpload } from 'primereact/fileupload';
import { InputNumber } from 'primereact/inputnumber';
import { InputText } from 'primereact/inputtext';
import { InputTextarea } from 'primereact/inputtextarea';
import { RadioButton } from 'primereact/radiobutton';
import { Rating } from 'primereact/rating';
import { Toast } from 'primereact/toast';
import { Toolbar } from 'primereact/toolbar';
import { classNames } from 'primereact/utils';
import React, { useEffect, useRef, useState } from 'react';
import {ManagerService}  from '../../../service/ManagerService';
import { Checkbox } from 'primereact/checkbox';
import { Dropdown } from 'primereact/dropdown';
        
const Crud = () => {

    let emptyAdmin = {
        id: null,
        name: '',
        image: null,
        description: '',
        category: null,
        price: 0,
        quantity: 0,
        rating: 0,
        inventoryStatus: 'INSTOCK'
    };

    const [roles, setRoles] = useState(null);
    const [admins, setAdmins] = useState(null);
    const [adminDialog, setAdminDialog] = useState(false);
    const [deleteAdminDialog, setDeleteAdminDialog] = useState(false);
    const [deleteAdminsDialog, setDeleteAdminsDialog] = useState(false);
    const [admin, setAdmin] = useState(emptyAdmin);
    const [selectedAdmins, setSelectedAdmins] = useState(null);
    const [submitted, setSubmitted] = useState(false);
    const [globalFilter, setGlobalFilter] = useState(null);
    const toast = useRef(null);
    const dt = useRef(null);


    useEffect(() => {
        const fetchAdmins = async () => {
            var result = await ManagerService.getAdminList();
            setAdmins(result);
        };
        fetchAdmins();
        const fectRoles = async () => {
            var result = await ManagerService.getRoles();
            var mapped = result.map((item) => {
                return {
                    label: item.name,
                    value: item.id
                }
            });
            setRoles(mapped);
        };
        fectRoles();
    }, []);


    const deleteAdmin = async () => {
        const result = await ManagerService.deleteAdmin(admin.id);
        if(result.status){
            toast.current.show({ severity: 'success', summary: 'Successful', detail: result.message, life: 2000 });
            let _admins = admins.filter((val) => val.id !== admin.id);
            setAdmins(_admins);
            setDeleteAdminDialog(false);
            setAdmin(emptyAdmin);
        }
        else{
            console.log(result);
            toast.current.show({ severity: 'warn', summary: 'Error', detail: result.message, life: 2000 });
        }
       
    };

    const saveAdmin = () => {
        setSubmitted(true);

        if (admin.name.trim()) {
            let _admins = [...admins];
            let _admin = { ...admin };
            if (admin.id) {
                const index = findIndexById(admin.id);

                _admins[index] = _admin;
                toast.current.show({ severity: 'success', summary: 'Successful', detail: 'Admin Updated', life: 3000 });
            } else {
                _admin.id = createId();
                _admin.code = createId();
                _admin.image = 'admin-placeholder.svg';
                _admins.push(_admin);
                toast.current.show({ severity: 'success', summary: 'Successful', detail: 'Admin Created', life: 3000 });
            }

            setAdmins(_admins);
            setAdminDialog(false);
            setAdmin(emptyAdmin);
        }
    };

    const formatCurrency = (value) => {
        return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
    };

    const openNew = () => {
        setAdmin(emptyAdmin);
        setSubmitted(false);
        setAdminDialog(true);
    };

    const hideDialog = () => {
        setSubmitted(false);
        setAdminDialog(false);
    };

    const hideDeleteAdminDialog = () => {
        setDeleteAdminDialog(false);
    };

    const hideDeleteAdminsDialog = () => {
        setDeleteAdminsDialog(false);
    };



    const editAdmin = (admin) => {
        setAdmin({ ...admin });
        setAdminDialog(true);
    };

    const confirmDeleteAdmin = (admin) => {
        setAdmin(admin);
        setDeleteAdminDialog(true);
    };

    const confirmEnableAdmin = (admin) => {
        setAdmin(admin);

        
    };

    const confirmDisableAdmin = (admin) => {
        setAdmin(admin);


    };



    const findIndexById = (id) => {
        let index = -1;
        for (let i = 0; i < admins.length; i++) {
            if (admins[i].id === id) {
                index = i;
                break;
            }
        }

        return index;
    };

    const createId = () => {
        let id = '';
        let chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        for (let i = 0; i < 5; i++) {
            id += chars.charAt(Math.floor(Math.random() * chars.length));
        }
        return id;
    };

    const exportCSV = () => {
        dt.current.exportCSV();
    };

    const confirmDeleteSelected = () => {
        setDeleteAdminsDialog(true);
    };

    const deleteSelectedAdmins = () => {
        let _admins = admins.filter((val) => !selectedAdmins.includes(val));
        setAdmins(_admins);
        setDeleteAdminsDialog(false);
        setSelectedAdmins(null);
        toast.current.show({ severity: 'success', summary: 'Successful', detail: 'Admins Deleted', life: 3000 });
    };

    const onCategoryChange = (e) => {
        let _admin = { ...admin };
        _admin['category'] = e.value;
        setAdmin(_admin);
    };

    const onInputChange = (e, name) => {
        const val = (e.target && e.target.value) || '';
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
        //<Button label="Delete" icon="pi pi-trash" severity="danger" onClick={confirmDeleteSelected} disabled={!selectedAdmins || !selectedAdmins.length} />
        return (
            <React.Fragment>
                <div className="my-2">
                    <Button label="New" icon="pi pi-plus" severity="sucess" className="mr-2" onClick={openNew} />
                    
                </div>
            </React.Fragment>
        );
    };

    const rightToolbarTemplate = () => {
        return (
            <React.Fragment>
                <FileUpload mode="basic" accept="image/*" maxFileSize={1000000} label="Import" chooseLabel="Import" className="mr-2 inline-block" />
                <Button label="Export" icon="pi pi-upload" severity="help" onClick={exportCSV} />
            </React.Fragment>
        );
    };

    const codeBodyTemplate = (rowData) => {
        return (
            <>
                <span className="p-column-title">Code</span>
                {rowData.code}
            </>
        );
    };

    const nameBodyTemplate = (rowData) => {
        return (
            <>
                <span className="p-column-title">Name</span>
                {rowData.name}
            </>
        );
    };

    const imageBodyTemplate = (rowData) => {
        return (
            <>
                <span className="p-column-title">Image</span>
                <img src={`/demo/images/admin/${rowData.image}`} alt={rowData.image} className="shadow-2" width="100" />
            </>
        );
    };

    const priceBodyTemplate = (rowData) => {
        return (
            <>
                <span className="p-column-title">Price</span>
                {rowData.price}
            </>
        );
    };

    const categoryBodyTemplate = (rowData) => {
        return (
            <>
                <span className="p-column-title">Category</span>
                {rowData.category}
            </>
        );
    };

    const ratingBodyTemplate = (rowData) => {
        return (
            <>
                <span className="p-column-title">Reviews</span>
                <Rating value={rowData.rating} readOnly cancel={false} />
            </>
        );
    };

    const statusBodyTemplate = (rowData) => {
        return (
            <>
                <span className="p-column-title">Status</span>
                <span className={`admin-badge status-${rowData.inventoryStatus.toLowerCase()}`}>{rowData.inventoryStatus}</span>
            </>
        );
    };

    const actionBodyTemplate = (rowData) => {
        var isDeleted = rowData.deletedDate != null;
        return (
            <>
                <Button icon="pi pi-pencil" visible={!isDeleted} severity="success" tooltip='Edit'  className="mr-2" tooltipOptions={{ position: 'bottom' }}onClick={() => editAdmin(rowData)} />
                <Button icon="pi pi-times" visible={!isDeleted} severity="warning" tooltip='Disable' className="mr-2" tooltipOptions={{ position: 'bottom' }} onClick={() => confirmDisableAdmin(rowData)} />
                <Button icon="pi pi-trash" visible={!isDeleted} severity="danger" tooltip='Delete' className="mr-2" tooltipOptions={{ position: 'bottom' }} onClick={() => confirmDeleteAdmin(rowData)} />
                <Button icon="pi pi-check" visible={isDeleted} severity="info" tooltip='Enable' className="mr-2" tooltipOptions={{ position: 'bottom' }} onClick={() => confirmEnableAdmin(rowData)} />
            </>
        );
    };

    const header = (
        <div className="flex flex-column md:flex-row md:justify-content-between md:align-items-center">
            <h5 className="m-0">Manage Admins</h5>
            <span className="block mt-2 md:mt-0 p-input-icon-left">
                <i className="pi pi-search" />
                <InputText type="search" onChange={(e) => setGlobalFilter(e.target.value)} placeholder="Search..." />
            </span>
        </div>
    );

    const adminDialogFooter = (
        <>
            <Button label="Cancel" icon="pi pi-times" text onClick={hideDialog} />
            <Button label="Save" icon="pi pi-check" text onClick={saveAdmin} />
        </>
    );
    const deleteAdminDialogFooter = (
        <>
            <Button label="No" icon="pi pi-times" text onClick={hideDeleteAdminDialog} />
            <Button label="Yes" icon="pi pi-check" text onClick={deleteAdmin} />
        </>
    );
    const deleteAdminsDialogFooter = (
        <>
            <Button label="No" icon="pi pi-times" text onClick={hideDeleteAdminsDialog} />
            <Button label="Yes" icon="pi pi-check" text onClick={deleteSelectedAdmins} />
        </>
    );

    const isValidBodyTemplate = (rowData) => {
        return (<Checkbox disabled checked={rowData.isValid}></Checkbox>);
    };
    return (
        <div className="grid crud-demo">
            <div className="col-12">
                <div className="card">
                    <Toast ref={toast} />
                    <Toolbar className="mb-4" left={leftToolbarTemplate} right={rightToolbarTemplate}></Toolbar>

                    <DataTable
                        ref={dt}
                        value={admins}
                        selection={selectedAdmins}
                        onSelectionChange={(e) => setSelectedAdmins(e.value)}
                        dataKey="id"
                        paginator
                        rows={10}
                        rowsPerPageOptions={[5, 10, 25]}
                        className="datatable-responsive"
                        paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                        currentPageReportTemplate="Showing {first} to {last} of {totalRecords} admins"
                        globalFilter={globalFilter}
                        emptyMessage="No admins found."
                        header={header}
                        responsiveLayout="scroll"
                    >

                        <Column field="registerDate" header="RegisterDate" sortable  headerStyle={{ minWidth: '15rem' }}></Column>
                        <Column field="isValid" header="IsValid" sortable body={isValidBodyTemplate} headerStyle={{ minWidth: '15rem' }}></Column>
                        <Column field="emailAddress" header="EmailAddress" sortable  headerStyle={{ minWidth: '15rem' }}></Column>
                        <Column field="deletedDate" header="DeletedDate" sortable  headerStyle={{ minWidth: '15rem' }}></Column>
                        <Column field="role.name" header="Role" sortable headerStyle={{ minWidth: '15rem' }}></Column>
                        <Column body={actionBodyTemplate} headerStyle={{ minWidth: '10rem' }}></Column>
                    </DataTable>

                    <Dialog visible={adminDialog} style={{ width: '450px' }} header="Admin Details" modal className="p-fluid" footer={adminDialogFooter} onHide={hideDialog}>
                        
                        <div className="field">
                            <label htmlFor="emailAddress">EmailAddress</label>
                            <InputText id="emailAddress" value={admin.emailAddress} onChange={(e) => onInputChange(e, 'emailAddress')} required rows={3} cols={20} />
                        </div>
                        <div className="field">
                            <label htmlFor="password">Password</label>
                            <InputText id="password" value={admin.password} onChange={(e) => onInputChange(e, 'password')} required rows={3} cols={20} />
                        </div>
                        <div className="field">
                            <label htmlFor="roleId">Role</label>
                          
                            <Dropdown value={admin.roleId} onChange={(e) => onInputChange(e, 'roleId')} options={roles} optionValue='value' optionLabel="label" placeholder="Select a Role" className="w-full md:w-14rem" />
                        </div>
                    </Dialog>
                    

                    <Dialog visible={deleteAdminDialog} style={{ width: '450px' }} header="Confirm" modal footer={deleteAdminDialogFooter} onHide={hideDeleteAdminDialog}>
                        <div className="flex align-items-center justify-content-center">
                            <i className="pi pi-exclamation-triangle mr-3" style={{ fontSize: '2rem' }} />
                            {admin && (
                                <span>
                                    Are you sure you want to delete <b>{admin.name}</b>?
                                </span>
                            )}
                        </div>
                    </Dialog>

                    <Dialog visible={deleteAdminsDialog} style={{ width: '450px' }} header="Confirm" modal footer={deleteAdminsDialogFooter} onHide={hideDeleteAdminsDialog}>
                        <div className="flex align-items-center justify-content-center">
                            <i className="pi pi-exclamation-triangle mr-3" style={{ fontSize: '2rem' }} />
                            {admin && <span>Are you sure you want to delete the selected admins?</span>}
                        </div>
                    </Dialog>
                </div>
            </div>
        </div>
    );
};

export default Crud;
