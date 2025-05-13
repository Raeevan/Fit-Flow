document.addEventListener('DOMContentLoaded', async function () {
    try {
        const views = [
            { id: 1, name: "Attendances", navURL: "/Attendances", pid: null },
            { id: 2, name: "Classes", navURL: "/Classes", pid: null },
            { id: 3, name: "Membership", navURL: "/Memberships", pid: null },
            { id: 4, name: "Member", navURL: "/People", pid: null },
            { id: 5, name: "Roles", navURL: "/Roles", pid: null }
        ];

        const mainMenu = new ej.navigations.TreeView({
            fullRowNavigable: true,
            fields: {
                dataSource: views,
                id: 'id',
                text: 'name',
                navigateUrl: 'navURL',
                parentID: 'pid',
                hasChildren: 'hasChild'
            },
            enablePersistence: false
        });
        mainMenu.appendTo('#mainMenu');
    } catch (error) {
        console.error('Error initializing sidebar menu:', error);
    }
});