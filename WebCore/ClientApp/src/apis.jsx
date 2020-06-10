import React from 'react';

export default class ApiService{
    // 获取更新时间
  async getLastUpdateInfo() {
    const response = await fetch(`Project/GetLastUpdateInfo`);
    const data = await response.json();
    console.log('获取最近更新时间:', data);
    return data;
  }
}