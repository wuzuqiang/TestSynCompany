/**
 * This class is the view model for the Main view of the application.
 */
Ext.define('app.view.main.MainModel', {
    extend: 'Ext.app.ViewModel',

    alias: 'viewmodel.main',

    data: {
        name: 'app',

        loremIpsum: 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',

        // ϵͳ��Ϣ
        system: {
            name: '������Ŀ��ͬ���ʽ����ϵͳ',
            version: '5.2014.06.60',
            iconUrl: ''
        },

        // �û���λ��Ϣ���û���Ϣ
        user: {
            company: '�䵱̫����˾',
            department: '���̲�',
            name: '������'
        },

        // ����λ�ͷ�����Ա��Ϣ
        service: {
            company: '����������˾',
            name: '����',
            phonenumber: '1320528----',
            qq: '78580822',
            email: 'jfok1972@qq.com',
            copyright: '������˾'
        }
    }

    //TODO - add data, formulas and/or methods to support your view
});
