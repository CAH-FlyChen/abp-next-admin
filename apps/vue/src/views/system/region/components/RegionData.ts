import { BasicColumn } from '/@/components/Table/src/types/table';
import { useLocalization } from '/@/hooks/abp/useLocalization';
import { Menu } from '/@/api/platform/menus/model';

const { L } = useLocalization('AppPlatform');

export function getDataColumns(): BasicColumn[] {
  return [
    {
      title: 'id',
      dataIndex: 'id',
      width: 1,
      ifShow: false,
    },
    {
      title: L('DisplayName:Code'),
      dataIndex: 'code',
      align: 'left',
      width: 150,
      resizable: true,
    },
    {
      title: L('DisplayName:Name'),
      dataIndex: 'name',
      align: 'left',
      width: 150,
      resizable: true,
    },
    {
      title: L('DisplayName:ParentCode'),
      dataIndex: 'parentCode',
      align: 'left',
      width: 180,
      resizable: true,
    },
    {
      title: L('DisplayName:RegionTypeCode'),
      dataIndex: 'regionTypeCode',
      align: 'left',
      width: 260,
      resizable: true,
    },
  ];
}
